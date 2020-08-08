using LoanSystem.Domain.Abstract;
using LoanSystem.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LoanSystem.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        
        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }

        public IEnumerable<Category> Categories
        {
            get { return context.Categories; }
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
                    dbEntry.Name = product.Name.ToUpper();
                    dbEntry.Description = product.Description.ToUpper();
                    dbEntry.CategoryID = product.CategoryID;
                    dbEntry.Unit = product.Unit;
                    //dbEntry.Price = product.Price;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                }
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int productID)
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
