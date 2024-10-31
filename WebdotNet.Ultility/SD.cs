using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdotNet.Utility
{
    public static class SD
    {
        public const string Role_User_Individual = "Customer";
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";

        public const string StatusPending = "Pending";
        public const string StatusApprove = "Approved";
        public const string StatusInProcess = "In Process";
        public const string StatusShipped = "Shipped";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";


        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApprove = "Approved";
        public const string PaymentStatusDelayedPayment = "Approved for delayed payment";
        public const string PaymentStatusRejected = "Rejected";

    }
}
