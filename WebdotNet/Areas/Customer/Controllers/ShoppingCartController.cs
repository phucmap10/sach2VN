using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebdotNet.DataAccess.Migrations;
using WebdotNet.DataAccess.Repository.IRepository;
using WebdotNet.Models.ViewModels;
using WebdotNet.Models;
using ShoppingCart = WebdotNet.Models.ShoppingCart;

namespace WebdotNet.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class ShoppingCartController : Controller
    {

        private readonly ILogger<ShoppingCartController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartVM ShoppingCartVM { get; set; }

        public ShoppingCartController(ILogger<ShoppingCartController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userID = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM = new ShoppingCartVM()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userID, includeProperties: "Product")

            };
            foreach (var list in ShoppingCartVM.ShoppingCartList)
            {
                list.Price = GetPrice(list);
                ShoppingCartVM.OrderTotal += (list.Price * list.Count);
            }
            return View(ShoppingCartVM);
        }
        public IActionResult plus(int cartID)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartID);
            cartFromDb.Count += 1;
            _unitOfWork.ShoppingCart.Update(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult minus(int cartID)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartID);
            if (cartFromDb.Count <= 1)
            {
                _unitOfWork.ShoppingCart.Remove(cartFromDb);
            }
            else
            {
                cartFromDb.Count -= 1;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
            }
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult remove(int cartID)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartID);
            _unitOfWork.ShoppingCart.Remove(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        private double GetPrice(ShoppingCart obj)
        {
            int x = obj.Count;
            if (x >= 100)
            {
                return obj.Product.Price100;
            }
            else if (x >= 50)
            {
                return obj.Product.Price50;
            }
            else
            {
                return obj.Product.Price;
            }
        }
    }
}
