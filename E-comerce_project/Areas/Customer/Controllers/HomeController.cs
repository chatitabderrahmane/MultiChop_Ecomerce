using E_comerce_project.Data;
using E_comerce_project.Models;
using E_comerce_project.Models.ViewsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
//Have fun watching my friends
namespace E_comerce_project.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;


        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _logger = logger;
            _db = db;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ShopingCart()
        {
            var userid = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
           
            var lSocialMedia = _db.SocialMedia.ToList();
            var lSocieteInfos = _db.SocieteInfos.ToList();
            var vm = new homeVM
            {
                ShopingCarts = _db.ShoppingCarts.Where(w => w.UserId == userid.Id).Include(x=>x.Product).ToList(),
                SocialMedia = lSocialMedia,
                SocieteInfos = lSocieteInfos
            };
            ViewBag.Subtotal = 0 ;
            ViewBag.Total = ViewBag.Subtotal + 10;
            
            return View(vm);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = _userManager.FindByIdAsync(userid).Result;
            ViewBag.Subtotal = 0;
            var model = new OrderVM
            {
                ApplicationUser = user,
                ShopingsCarts = _db.ShoppingCarts.Where(w => w.UserId == userid).Include(x => x.Product).ToList(),
            }; 
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CheckoutPost()
        {
             
            return RedirectToAction("OrderCompleted");
        }
        [HttpGet]
        public async Task<IActionResult> OrderCompleted()
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = _userManager.FindByIdAsync(userid).Result;
            ViewBag.Subtotal = 0;
            var model = new OrderVM
            {
                ApplicationUser = user,
                ShopingsCarts = _db.ShoppingCarts.Where(w => w.UserId == userid).Include(x => x.Product).ToList(),
            };
            return View(model);
            
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ShopingCart(int? id)
        {
            var userid = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
           // ViewBag.QtySubtotal = _db.ShoppingCarts.Where(w=>w.UserId == userid.Id).Sum(w=>w.Qty);
            ViewBag.count= _db.ShoppingCarts.Where(w => w.UserId == userid.Id).Count();   
            ViewBag.Subtotal = _db.ShoppingCarts.Where(w => w.UserId == userid.Id).Include(x => x.Product).Sum(w => w.Product.New_Price  );
            ViewBag.Subtotal = ViewBag.QtySubtotal * ViewBag.priceSubtotal;
           // ViewBag.Total = ViewBag.Subtotal + 10;
            return View();
        }
   
        public IActionResult DeletefromShopingCart(int? Id)
        {
         
            var ShoppingCartid = _db.ShoppingCarts.FirstOrDefault(w => w.Id == Id); 
            _db.ShoppingCarts.Remove(ShoppingCartid);
            _db.SaveChanges();
            return RedirectToAction("ShopingCart");
        }
        [Authorize]
        public async Task<IActionResult> AddToShopingCart(ShopingCart obj,int ProId)
        {
            var userid = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            if (obj.Qty < 1) obj.Qty = 1;
            var model = new ShopingCart()
            {
                UserId = userid.Id,
                ProId = ProId,
                Qty = obj.Qty,  
            };
      
             
            _db.ShoppingCarts.Add(model);
            _db.SaveChanges();
            return RedirectToAction("ShopingCart");
        }
        public IActionResult Index()
        {
            var LProducts = _db.Products.ToList();
            var LCategory = _db.Categories.ToList();
            var lSocialMedia = _db.SocialMedia.ToList();
            var lSocieteInfos = _db.SocieteInfos.ToList();
            var vm = new homeVM 
            {
                Products = LProducts,
                Categories = LCategory,
                SocialMedia=lSocialMedia,
                SocieteInfos = lSocieteInfos
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }
     

        [HttpPost]
        public IActionResult Newsletter(Newsletter obj)
        {
          
            _db.Newsletter.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult SocialMedia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(string keywords)
        {
            var LProducts = _db.Products.Where(x => x.Name.Contains(keywords)).ToList();
            var LCategory = _db.Categories.ToList();
            var lSocialMedia = _db.SocialMedia.ToList();
            var lSocieteInfos = _db.SocieteInfos.ToList();
            var vm = new homeVM
            {
                Products = LProducts,
                Categories = LCategory,
                SocialMedia = lSocialMedia,
                SocieteInfos = lSocieteInfos,
                
            };
            if (LProducts.Count > 0)
                ViewBag.result = "Your result for " + keywords + " :";
            else
                ViewBag.result = null;

            ViewBag.keywords = keywords;
            return View(vm);
            
            

           
        }

      
        [HttpGet]
        public IActionResult Products()
        {

            var LProducts = _db.Products.ToList();
            var LCategory = _db.Categories.ToList();
            var lSocialMedia = _db.SocialMedia.ToList();
            var lSocieteInfos = _db.SocieteInfos.ToList();
            var vm = new homeVM
            {
                Products = LProducts,
                Categories = LCategory,
                SocialMedia = lSocialMedia,
                SocieteInfos = lSocieteInfos
            };
            return View(vm);
        }
        [HttpGet]
        public IActionResult Details(int? Id)
        {
            if (Id != null)
            {
                var LProducts = _db.Products.OrderBy(r => EF.Functions.Random()).Take(3).ToList();
                var LCategory = _db.Categories.ToList();
                var lSocialMedia = _db.SocialMedia.ToList();
                var lSocieteInfos = _db.SocieteInfos.ToList();
                var vm = new homeVM
                {
                    Products = LProducts,
                    Categories = LCategory,
                    SocialMedia = lSocialMedia,
                    SocieteInfos = lSocieteInfos,
                    Product = _db.Products.Include(p => p.Category).FirstOrDefault(x => x.ProId == Id),
                    specifications = _db.Specifications.Where(x => x.ProId == Id).ToList(),  
                };
                return View(vm);
            }
            else
                return RedirectToAction("index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}