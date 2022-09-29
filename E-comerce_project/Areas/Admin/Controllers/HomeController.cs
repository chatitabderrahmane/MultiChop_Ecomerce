using E_comerce_project.Data;
using Microsoft.AspNetCore.Mvc;

namespace E_comerce_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {

            _db = db;
        }
        public IActionResult Index()
        {
            var Numbersubscribers = _db.Newsletter.Count()     ;
            var NumberProducts = _db.Products.ToList().Count();
           ViewBag.Numbersubscribers = Numbersubscribers;   
            ViewBag.NumberProducts = NumberProducts;    

           
            return View();
        }
    }
}
