using LoanSystem.Domain.Entities;
using System.Data.Entity;

namespace LoanSystem.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}
