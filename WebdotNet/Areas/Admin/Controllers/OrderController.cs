using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebdotNet.DataAccess.Repository;
using WebdotNet.DataAccess.Repository.IRepository;
using WebdotNet.Models;

namespace WebdotNet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<OrderHeader> objOrder = _unitOfWork.OrderHeader.GetAll(includeProperties:"ApplicationUser").ToList();
            return Json(new { data = objOrder });
        }
        #endregion
    }
}
