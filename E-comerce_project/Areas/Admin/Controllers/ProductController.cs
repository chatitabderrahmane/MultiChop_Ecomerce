using E_comerce_project.Data;
using E_comerce_project.Models;
using E_comerce_project.Models.ViewsModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;

namespace E_comerce_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly IWebHostEnvironment _hostEnvironment;
       public ProductController(ApplicationDbContext db ,IWebHostEnvironment  hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        { 
            var Products = _db.Products.Include(c => c.Category).ToList();
            return View(Products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var Categories = _db.Categories.ToList();
            var CategoriesList = new SelectList(Categories, "Id", "Name");
            ViewBag.Categories = CategoriesList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj, IFormFile file, IFormFile file2)
        {
            
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(_hostEnvironment.WebRootPath, @"Areas\Admin\Images\Products\");
                    wwwRootPath = Path.Combine(_hostEnvironment.WebRootPath, file.Name);
                    var extention = Path.GetExtension(file.FileName);
                    using (var fileStreams = new FileStream(Path.Combine(uploads, FileName + extention), FileMode.Create))
                    {
                       file.CopyTo(fileStreams);
                    }
                 obj.image1 = FileName + extention;

            }
            if (file2 != null)
            {
                string FileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(_hostEnvironment.WebRootPath, @"Areas\Admin\Images\Products\");
                wwwRootPath = Path.Combine(_hostEnvironment.WebRootPath, file2.Name);
                var extention = Path.GetExtension(file2.FileName);
                using (var fileStreams = new FileStream(Path.Combine(uploads, FileName + extention), FileMode.Create))
                {
                    file2.CopyTo(fileStreams);
                }
                obj.image2 = FileName + extention;
            }
            _db.Products.Add(obj);
            _db.SaveChanges();
            var Categories = _db.Categories.ToList();
            var CategoriesList = new SelectList(Categories, "Id", "Name");
            ViewBag.Categories = CategoriesList;
            return RedirectToAction("index");  
            
        }
    
        public IActionResult CreateAndNext(Product obj, IFormFile file, IFormFile file2)
        {

            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                string FileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(_hostEnvironment.WebRootPath, @"Areas\Admin\Images\Products\");
                wwwRootPath = Path.Combine(_hostEnvironment.WebRootPath, file.Name);
                var extention = Path.GetExtension(file.FileName);
                using (var fileStreams = new FileStream(Path.Combine(uploads, FileName + extention), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                obj.image1 = FileName + extention;

            }
            if (file2 != null)
            {
                string FileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(_hostEnvironment.WebRootPath, @"Areas\Admin\Images\Products\");
                wwwRootPath = Path.Combine(_hostEnvironment.WebRootPath, file2.Name);
                var extention = Path.GetExtension(file2.FileName);
                using (var fileStreams = new FileStream(Path.Combine(uploads, FileName + extention), FileMode.Create))
                {
                    file2.CopyTo(fileStreams);
                }
                obj.image2 = FileName + extention;
            }

            
            _db.Products.Add(obj);
            _db.SaveChanges();
            HttpContext.Session.SetInt32("ProId", obj.ProId);

            var Categories = _db.Categories.ToList();
            var CategoriesList = new SelectList(Categories, "Id", "Name");
            ViewBag.Categories = CategoriesList;
            return RedirectToAction("CreateSpecification");

        
         }
       
        [HttpGet]
        public IActionResult CreateSpecification( )
        {
            int RProId2;


            if (HttpContext.Session.GetInt32("GetProId") != null)
            {
                 RProId2 = (int)HttpContext.Session.GetInt32("GetProId");
                
            }
            else
                 RProId2 = (int)HttpContext.Session.GetInt32("ProId");
            var model = new Product_specifications()
            {
                specifications = _db.Specifications.Where(x => x.ProId== RProId2).ToList(), 
            };
            return View(model);
        }
        [HttpPost]
        public   IActionResult CreateSpecification(specification obj)
        {
            int RProId = (int) HttpContext.Session.GetInt32("ProId");

            obj.ProId = RProId;
            HttpContext.Session.SetInt32("GetProId", RProId);
            _db.Specifications.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("CreateSpecification");  
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {

            var Categories = _db.Categories.ToList();
            var CategoriesList = new SelectList(Categories, "Id", "Name");
            ViewBag.Categories = CategoriesList;
            string wwwRootPath = _hostEnvironment.WebRootPath;
       
            if (id != null)
            {
                var Product = _db.Products.FirstOrDefault(c => c.ProId == id);
                return View(Product);
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Edit(int id, Product obj, IFormFile file, IFormFile file2)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;

            if (file != null)
            {
                string FileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(_hostEnvironment.WebRootPath, @"Areas\Admin\Images\Products\");
                wwwRootPath = Path.Combine(_hostEnvironment.WebRootPath, file.Name);
                var extention = Path.GetExtension(file.FileName);
                using (var fileStreams = new FileStream(Path.Combine(uploads, FileName + extention), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                obj.image1 = FileName + extention;

            }
            else
            {
                obj.image1 = obj.image1;
            }
            if (file2 != null)
            {
                string FileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(_hostEnvironment.WebRootPath, @"Areas\Admin\Images\Products\");
                wwwRootPath = Path.Combine(_hostEnvironment.WebRootPath, file2.Name);
                var extention = Path.GetExtension(file2.FileName);
                using (var fileStreams = new FileStream(Path.Combine(uploads, FileName + extention), FileMode.Create))
                {
                    file2.CopyTo(fileStreams);
                }
                obj.image2 = FileName + extention;
            }
            else
            {
                obj.image2= obj.image2;
            }
            _db.Products.Update(obj);
            _db.SaveChanges();
            var Categories = _db.Categories.ToList();
            var CategoriesList = new SelectList(Categories, "Id", "Name");
            ViewBag.Categories = CategoriesList;

            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var Categories = _db.Categories.ToList();
            var CategoriesList = new SelectList(Categories, "Id", "Name");
            ViewBag.Categories = CategoriesList;
            if (id != null)
            {
                var Product = _db.Products.FirstOrDefault(c => c.ProId == id);
                return View(Product); 
            }
            return RedirectToAction("index");

        }
        [HttpPost]
 
        public IActionResult DeletePost(int ProId)
        {
            
            
            var ProductId = _db.Products.Find(ProId);
            _db.Products.Remove(ProductId);
            _db.SaveChanges();
            return RedirectToAction("index");
        }

    }
}

