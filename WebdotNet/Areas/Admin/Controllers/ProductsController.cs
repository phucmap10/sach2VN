using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebdotNet.DataAccess.Data;
using WebdotNet.DataAccess.Repository;
using WebdotNet.DataAccess.Repository.IRepository;
using WebdotNet.Models;
namespace WebdotNet.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork UnitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = UnitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Products> objProduct = _unitOfWork.Products.GetAll().ToList();
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Name
            });
            return View(objProduct);
        }
        public IActionResult Create()
        {
            List<Products> objProduct = _unitOfWork.Products.GetAll().ToList();
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Name
            });
            ViewBag.CategoryList = CategoryList;
            return View();
        }//this is for getting input from user
        //when we have input, we will create
        [HttpPost]
        public IActionResult Create(Products obj, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if(file != null)
            {
                string file_name = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, @"images\products");
                using (var fileStream = new FileStream(Path.Combine(productPath, file_name), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                obj.imgUrl = @"\images\products\" + file_name;
            }
            //Custom validation for system
            if (ModelState.IsValid)
            {
                _unitOfWork.Products.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Products has been created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Products? ProductfromDb = _unitOfWork.Products.Get(u => u.ID == id);
            if (ProductfromDb == null)
            {
                return NotFound();
            }
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Name
            });
            ViewBag.CategoryList = CategoryList;
            return View(ProductfromDb);
        }
        [HttpPost]
        public IActionResult Edit(Products obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Products.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product has been updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Products? ProductfromDb = _unitOfWork.Products.Get(u => u.ID == id);
            if (ProductfromDb == null)
            {
                return NotFound();
            }
            return View(ProductfromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Products obj = _unitOfWork.Products.Get(u => u.ID == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Products.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product has been removed";
            return RedirectToAction("Index");

        }
    }
}