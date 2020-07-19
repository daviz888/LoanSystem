using LoanSystem.Domain.Entities;
using System.Collections.Generic;

namespace LoanSystem.Domain.Abstract
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Customers { get; }

        void SaveCustomer(Customer customer);

        Customer DeleteCustomer(int customerId);
    }
}
