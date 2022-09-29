using E_comerce_project.Data;
using E_comerce_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_comerce_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CategoryController(ApplicationDbContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment= hostEnvironment;  
        }

        public IActionResult Index()
        {
                 
            var Categories=  _db.Categories.ToList();
            return View(Categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj,IFormFile file)
        {
            
                string wwwRootPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                string FileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"Areas\Admin\Images\Categories\");
                wwwRootPath = Path.Combine(wwwRootPath, file.Name);
                var extention = Path.GetExtension(file.FileName);
                using (var fileStreams = new FileStream(Path.Combine(uploads, FileName + extention), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                obj.Image =   FileName + extention;

                _db.Categories.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("index");
            }
            return View(obj);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
               var category = _db.Categories.FirstOrDefault(c => c.Id == id);
                return View(category);
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Edit( int id,Category obj,IFormFile file)
        {
            

     
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                string FileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"Areas\Admin\Images\Categories\");
                wwwRootPath = Path.Combine(wwwRootPath, file.Name);
                var extention = Path.GetExtension(file.FileName);
                using (var fileStreams = new FileStream(Path.Combine(uploads, FileName + extention), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                obj.Image =  FileName + extention;
            }
            else
            {

                obj.Image = obj.Image;
            }
             
            _db.Categories.Update(obj);
            _db.SaveChanges();  
            return RedirectToAction("index", "Category");
             
            

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var category = _db.Categories.FirstOrDefault(c => c.Id == id);
                return View(category);
            }
            return RedirectToAction("index");

        }
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var Categoryid=_db.Newsletter.Find(id);
            _db.Newsletter.Remove(Categoryid);
            _db.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
