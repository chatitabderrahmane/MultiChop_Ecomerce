using E_comerce_project.Data;
using E_comerce_project.Models;
using E_comerce_project.Models.ViewsModel;
using Microsoft.AspNetCore.Mvc;

namespace E_comerce_project.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _db;


        public ContactController(  ApplicationDbContext db)
        {
               _db = db;
        }
       
        [HttpGet]
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
                SocialMedia = lSocialMedia,
                SocieteInfos = lSocieteInfos
            };

            return View(vm);
        }
        [HttpPost]
        public IActionResult Index(Contact Contact)
        {
            _db.Contacts.Add(Contact);
            _db.SaveChanges();
            return View();

        }
    }
}
