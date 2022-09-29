using E_comerce_project.Data;
using E_comerce_project.Models;
using E_comerce_project.Models.ViewsModel;
using Microsoft.AspNetCore.Mvc;

namespace E_comerce_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _db;


        public ContactController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_db.Contacts.ToList());
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
