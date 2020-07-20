using LoanSystem.Domain.Abstract;
using LoanSystem.Domain.Entities;
using System.Collections.Generic;

namespace LoanSystem.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
