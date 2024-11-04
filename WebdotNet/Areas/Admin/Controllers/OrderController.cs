using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using WebdotNet.DataAccess.Repository;
using WebdotNet.DataAccess.Repository.IRepository;
using WebdotNet.Models;
using WebdotNet.Models.ViewModels;
using WebdotNet.Utility;

namespace WebdotNet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public OrderVM orderVM { get; set; }
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int orderID)
        {
            orderVM = new()
            {
                orderHeader = _unitOfWork.OrderHeader.Get(u => u.ID == orderID),
                orderDetail = _unitOfWork.OrderDetail.GetAll(o => o.OrderHeader.ID == orderID, includeProperties: "Product"),
            };
            orderVM.orderHeader.ApplicationUser = _unitOfWork.ApplicationUser.Get(o => o.Id == orderVM.orderHeader.ApplicationUserID);
            return View(orderVM);
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult UpdateOrderDetails()
        {
            var OrderHeaderfromDb = _unitOfWork.OrderHeader.Get(u => u.ID == orderVM.orderHeader.ID);
            if(string.IsNullOrEmpty(orderVM.orderHeader.Carrier))
            {
                OrderHeaderfromDb.Carrier = "Not Shipped";
            }
            else
            {
                OrderHeaderfromDb.Carrier = orderVM.orderHeader.Carrier;
            }
            _unitOfWork.OrderHeader.Update(OrderHeaderfromDb);
            TempData["Success"] = "Order Details Updated Successfully";
            _unitOfWork.Save();
            return RedirectToAction(nameof(Details), new{orderID = OrderHeaderfromDb.ID });
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult ShipOrder()
        {
            var OrderHeaderfromDb = _unitOfWork.OrderHeader.Get(u => u.ID == orderVM.orderHeader.ID);
            if (string.IsNullOrEmpty(orderVM.orderHeader.Carrier) || orderVM.orderHeader.Carrier == "Not Shipped")
            {
                OrderHeaderfromDb.Carrier = "Shopee Express";
            }
            else
            {
                OrderHeaderfromDb.Carrier = orderVM.orderHeader.Carrier;
            }
            _unitOfWork.OrderHeader.Update(OrderHeaderfromDb);
            TempData["Success"] = "Order Details Shipped Successfully";
            _unitOfWork.Save();
            return RedirectToAction(nameof(Details), new { orderID = OrderHeaderfromDb.ID });
        }

        [HttpPost]
        public IActionResult CancelOrder()
        {
            var OrderHeaderfromDb = _unitOfWork.OrderHeader.Get(u => u.ID == orderVM.orderHeader.ID);
            var options = new RefundCreateOptions
            {
                Reason = RefundReasons.RequestedByCustomer,
                PaymentIntent = orderVM.orderHeader.TransactionID
            };
            var service = new RefundService();
            Refund refund = service.Create(options);
            _unitOfWork.OrderHeader.UpdateStatus(orderVM.orderHeader.ID, SD.StatusCancelled, SD.StatusRefunded);
            _unitOfWork.Save();
            TempData["Success"] = "Order Cancelled";
            return RedirectToAction(nameof(Details), new { orderID = OrderHeaderfromDb.ID });
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll(string status)
        {
            IEnumerable<OrderHeader> objOrderHeaders;


            if (User.IsInRole(SD.Role_Admin) || User.IsInRole(SD.Role_Employee))
            {
                objOrderHeaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser").ToList();
            }
            else
            {

                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                objOrderHeaders = _unitOfWork.OrderHeader
                    .GetAll(u => u.ApplicationUserID == userId, includeProperties: "ApplicationUser");
            }


            switch (status)
            {
                case "pending":
                    objOrderHeaders = objOrderHeaders.Where(u => u.PaymentStatus == SD.PaymentStatusDelayedPayment);
                    break;
                case "inprocess":
                    objOrderHeaders = objOrderHeaders.Where(u => u.OrderStatus == SD.StatusInProcess);
                    break;
                case "completed":
                    objOrderHeaders = objOrderHeaders.Where(u => u.OrderStatus == SD.StatusShipped);
                    break;
                case "approved":
                    objOrderHeaders = objOrderHeaders.Where(u => u.OrderStatus == SD.StatusApprove);
                    break;
                default:
                    break;

            }


            return Json(new { data = objOrderHeaders });
        }
        #endregion


    }
}
