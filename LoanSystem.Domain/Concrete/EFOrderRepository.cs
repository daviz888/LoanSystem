using LoanSystem.Domain.Abstract;
using LoanSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSystem.Domain.Concrete
{
    public class EFOrderRepository:IOrderRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Order> Orders
        {
            get { return context.Orders; }
        }

        public void SaveOrders(List<Order> orders)
        {
            foreach (var order in orders)
            {
                if (order.OrderID == 0)
                {
                    context.Orders.Add(order);
                }
                else
                {
                    Order dbEntry = context.Orders.Find(order.OrderID);
                    if (dbEntry != null)
                    {
                        dbEntry.CustomerID = order.CustomerID;
                        dbEntry.OrderDate = order.OrderDate;

                    }
                }
                context.SaveChanges();
            }
                      
        }

        public Order DeleteOrder(int orderID)
        {
            Order orderToRemove = context.Orders.Find(orderID);
            if (orderToRemove != null)
            {
                context.Orders.Remove(orderToRemove);
                context.SaveChanges();
            }
            return orderToRemove;
        }
    }
}
