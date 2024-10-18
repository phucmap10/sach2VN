using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebdotNet.Data;
using WebdotNet.Models;

namespace WebdotNet.Controllers
{
    public class CategoryController : Controller
    {   
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategory = _db.Categories.ToList();
            return View(objCategory);
        }
        public IActionResult Create()
        {
            return View();
        }//this is for getting input from user
        //when we have input, we will create
        [HttpPost]
        public IActionResult Create(Category obj)
        {   if(obj.Name != null && obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name" /* if we dont specify any property like "name", the summary of Model only will not display this as error of name*/, "Name and DisplayOrder can not be the same");
            }//Custom validation for system
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
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
            Category? categoryfromDb = _db.Categories.Find(id);
            if(categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }
        /*public IActionResult Edit(Category obj)
        {
            if (obj.Name != null && obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and DisplayOrder can not be the same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }*/
    }
}
