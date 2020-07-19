using LoanSystem.Domain.Abstract;
using LoanSystem.Domain.Entities;
using System.Collections.Generic;

namespace LoanSystem.Domain.Concrete
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Customer> Customers
        {
            get { return context.Customers; }
        }

        public void SaveCustomer(Customer customer)
        {
            if (customer.CustomerID == 0)
            {
                context.Customers.Add(customer);
            }
            else
            {
                Customer dbEntry = context.Customers.Find(customer.CustomerID);
                if (dbEntry != null)
                {
                    dbEntry.FirstName = customer.FirstName;
                    dbEntry.LastName = customer.LastName;
                    dbEntry.Address = customer.Address;
                    dbEntry.City = customer.City;
                    dbEntry.State = customer.State;
                    dbEntry.Zip = customer.Zip;
                }
            }
            context.SaveChanges();
        }

        public Customer DeleteCustomer(int customerId)
        {
            Customer dbEntry = context.Customers.Find(customerId);
            if (dbEntry != null)
            {
                context.Customers.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
