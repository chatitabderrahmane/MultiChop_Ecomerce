using E_comerce_project.Data;
using E_comerce_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_comerce_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly ApplicationDbContext _db;


        public SocialMediaController(ApplicationDbContext db)
        {
             
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.SocialMedia.FirstOrDefault(x=>x.Id==4));
        }
        [HttpPost]
        public IActionResult Edit(int Id, SocialMedia obj)
        {
            if(Id!=null)
            {
                _db.SocialMedia.Update(obj);
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
