using E_comerce_project.Data;
using Microsoft.AspNetCore.Mvc;

namespace E_comerce_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsletterController : Controller
    {
        private readonly ApplicationDbContext _db;
        public NewsletterController(ApplicationDbContext db)
        {

            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Newsletter.ToList());
        }
        public IActionResult Delete(int id)
        {
            var Newsletterid = _db.Newsletter.Find(id);
            _db.Newsletter.Remove(Newsletterid);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
