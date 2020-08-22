using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSystem.Domain.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int PriceID { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public Decimal Amount { get; set; }

        public virtual Product Products { get; set; }
        public virtual Customer Customers { get; set; }
        public virtual Price Prices { get; set; }
    }

}
