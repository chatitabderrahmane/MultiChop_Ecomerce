using E_comerce_project.Data;
using E_comerce_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_comerce_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocieteInfosController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SocieteInfosController(ApplicationDbContext db)
        {

            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.SocieteInfos.FirstOrDefault(x => x.Id == 1));
            
        }
        [HttpPost]
        public IActionResult Index(int Id, SocieteInfos obj)
        {
            if (Id != null)
            {
                _db.SocieteInfos.Update(obj);
                _db.SaveChanges();

                return RedirectToAction("index", "Home");

            }
            else
            {
                return View();
            }


        }
    }
}
