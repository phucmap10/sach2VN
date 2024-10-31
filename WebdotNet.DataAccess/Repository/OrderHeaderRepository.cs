using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebdotNet.DataAccess.Data;
using WebdotNet.DataAccess.Repository.IRepository;
using WebdotNet.Models;

namespace WebdotNet.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderHeader orderHeader)
        {
            _db.OrderHeaders.Update(orderHeader);
        }
        public void UpdateStatus(int id, string status, string? paymentStatus = null)
        {
            var orderHeader = _db.OrderHeaders.FirstOrDefault(o => o.ID == id);
            if (orderHeader != null)
            {
                orderHeader.OrderStatus = status;
                if (!string.IsNullOrEmpty(paymentStatus))
                {
                    orderHeader.PaymentStatus = paymentStatus;
                }
            }
        }
        public void UpdateStripePaymentID(int id, string sessionId, string paymentID)
        {
            var orderHeader = _db.OrderHeaders.FirstOrDefault(o => o.ID == id);
            if (orderHeader != null)
            {
                if(!string.IsNullOrEmpty(sessionId))
                {
                    orderHeader.SessionID = sessionId;
                }
                if(!string.IsNullOrEmpty(paymentID))
                {
                    orderHeader.TransactionID = paymentID;
                    orderHeader.PaymentDate = DateTime.Now;
                }
            }
        }
    }
}
