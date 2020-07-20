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

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Description = product.Description.ToUpper();
                    dbEntry.Unit = product.Unit.ToUpper();
                    dbEntry.Price = product.Price;
                }
            }
            context.SaveChanges();
        }

        Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.Find(productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
