using LoanSystem.Domain.Entities;
using System.Data.Entity;

namespace LoanSystem.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
