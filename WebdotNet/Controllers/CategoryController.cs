using Microsoft.AspNetCore.Mvc;
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
        {   
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
