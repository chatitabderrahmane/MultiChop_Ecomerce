using E_comerce_project.Data;
using E_comerce_project.Models;
using E_comerce_project.Models.ViewsModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_comerce_project.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;
         public AccountController(SignInManager<ApplicationUser> signInManager,UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
              _userManager = userManager;
             _signInManager = signInManager;
            _db = db;
        }
         public IActionResult Login()
         {
            var lSocialMedia = _db.SocialMedia.ToList();
            var lSocieteInfos = _db.SocieteInfos.ToList();
            var vm = new homeVM
            {
                SocialMedia = lSocialMedia,
                SocieteInfos = lSocieteInfos
            };
            return View(vm);
         }
         [HttpPost]
         public  async Task<IActionResult> Login(LoginVM model)
         {
            if (ModelState.IsValid)
            {
                //Remember me
                bool ischecked = model.RememberMe;
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password,ischecked, false);
                if (result.Succeeded)
                {   
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    return RedirectToAction("Login", model);
                }
            }
            return RedirectToAction("Login", model);

        }
         public IActionResult Register()
         { 
            var lSocialMedia = _db.SocialMedia.ToList();
            var lSocieteInfos = _db.SocieteInfos.ToList();
            var vm = new homeVM
            {
                SocialMedia = lSocialMedia,
                SocieteInfos = lSocieteInfos     
            };
            return View(vm);
         }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {

                 var user = new ApplicationUser
                 {
                    Id = model.Id,
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                    City = model.City,
                    Adress=model.Adress,
                    PhoneNumber = model.PhoneNumber,
                    
                 };
                      
                 user.Id = Guid.NewGuid().ToString();
                 var result = await _userManager.CreateAsync(user,model.Password);
                  if (result.Succeeded)
                  {
                    //await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Login","Account");

                  }
                  else
                  {
                    return RedirectToAction("Register");
                  }
            }

            return RedirectToAction("Register");

        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index","Home");
        }

    }
}
