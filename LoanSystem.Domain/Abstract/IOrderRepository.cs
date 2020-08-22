using LoanSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSystem.Domain.Abstract
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrders(List<Order> orders);

        Order DeleteOrder(int orderID);

        //IEnumerable<Account> Accounts { get; }

    }
}
