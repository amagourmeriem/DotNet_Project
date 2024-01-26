using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Construction;
using ModElle.DataAccess.Data;
using ModElle.DataAccess.Repository;
using ModElle.DataAccess.Repository.IRepository;
using ModElle.Models;
using ModElle.Models.ViewModels;
using ModElle.Utility;


namespace ModElleWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class ProductController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()

        {
            List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties:"Category").ToList();

            return View(objProductList);
        }
        public IActionResult Upsert(int? id) 
        {
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()
                }),
                Product = new Product()
            };
            if(id==null || id == 0)
            {
                //create
                return View(productVM);
            }
            else
            {
                //update
                productVM.Product=_unitOfWork.Product.Get(u=>u.Id==id);
                return View(productVM);
            }
          
        }
     

        [HttpPost]
        public IActionResult Upsert(ProductVM ProductVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string projectPath = Path.Combine(wwwRootPath, @"Images\projects");

                    if (!string.IsNullOrEmpty(ProductVM.Product.ImageUrl))
                    {
                        //delete old image
                        var oldimage = Path.Combine(wwwRootPath, ProductVM.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldimage))
                        {
                            System.IO.File.Delete(oldimage);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(projectPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    ProductVM.Product.ImageUrl= @"\Images\projects\" + fileName;
                }
                if (ProductVM.Product.ImageUrl == null)
                {
                    _unitOfWork.Product.Add(ProductVM.Product);
                    TempData["success"] = "Project created successfully";
                }
                else
                {
                    _unitOfWork.Product.Update(ProductVM.Product);
                    TempData["success"] = "Project updated successfully";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ProductVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()
                });
                return View(ProductVM);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? ProductFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            //Product? ProductFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Product? ProductFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();


            if (ProductFromDb == null)
            {
                return NotFound();
            }
            return View(ProductFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Catégorie supprimée avec succès.";
            return RedirectToAction("Index");
        }
    }

}


