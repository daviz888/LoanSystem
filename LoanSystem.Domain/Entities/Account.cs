using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSystem.Domain.Entities
{
    public class Account
    {
        public int AccountID { get; set; }
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime AccountDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal InterestAmount { get; set; }
        public decimal PrincipalPayment { get; set; }
        public decimal InterestPayment { get; set; }
        public decimal Balance { get; set; }
        public bool? PayFlag { get; set; }
        public int ControlNo { get; set; }

        public virtual Order Orders { get; set; }
        public virtual Customer Customers { get; set; }

    }
}
