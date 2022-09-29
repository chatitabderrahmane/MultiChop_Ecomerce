using E_comerce_project.Data;
using E_comerce_project.Models;
using E_comerce_project.Models.ViewsModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace E_comerce_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ImagesProductController : Controller
    { 
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImagesProductController(ApplicationDbContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment= hostEnvironment;  
        }

        public IActionResult Index()
        {
            var Productsa = _db.Products.ToList();
            var ProductImagesa = _db.ProductImages.ToList();
            //var vm = new List<homeVM>()
            //{
            //      new homeVM(){
            //              Products = Productsa.ToList(),
            //              ProductImages = ProductImagesa.ToList(), 
            //      }
            //};

            return View( );
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.images = new SelectList(_db.Products.ToList(), "ProId", "Name");
            ProImages vm = new ProImages();  
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(ProImages vm)
        {
           foreach(var item in vm.Images)
            {
                string stringfilename= UplodsImages(item);

                var productimages = new ProductImages
                {
                    ProductImage = stringfilename,
                    ProId = vm.Product.ProId
                  
                };
                _db.ProductImages.Add(productimages);
                _db.SaveChanges();
            }
                    
               
           return RedirectToAction("index");  
        }

        private string UplodsImages(IFormFile file)
        {
             
            string fileName = null;

            if (file != null)
            {
                var uploads = Path.Combine(_hostEnvironment.WebRootPath, @"Areas\Admin\Images\Products\");
                fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
              
                string filePath = Path.Combine(uploads, fileName);  
                using (var fileStreams = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
            }
            return fileName;
        }
           [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
               var ProductImages = _db.ProductImages.FirstOrDefault(c => c.Id == id);
                return View(ProductImages);
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Edit( int id,ProductImages obj,IFormFile file)
        {
            

     
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                string FileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"Area\Admin\Images\Products\");
                wwwRootPath = Path.Combine(wwwRootPath, file.Name);
                var extention = Path.GetExtension(file.FileName);
                using (var fileStreams = new FileStream(Path.Combine(uploads, FileName + extention), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                obj.ProductImage = @"Area\Admin\Images\Products\" + FileName + extention;
            }
            else
            {

                obj.ProductImage = obj.ProductImage;
            }
             
            _db.ProductImages.Update(obj);
            _db.SaveChanges();  
            return RedirectToAction("index");
             
            

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var ProductImages = _db.ProductImages.FirstOrDefault(c => c.Id == id);
                return View(ProductImages);
            }
            return RedirectToAction("index");

        }
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var ProductImagesid=_db.ProductImages.Find(id);
            _db.ProductImages.Remove(ProductImagesid);
            _db.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
