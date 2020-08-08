using LoanSystem.Domain.Abstract;
using LoanSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSystem.Domain.Concrete
{
    public class EFPriceRepository : IPriceRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Price> Prices
        {
            get { return context.Prices; }
        }

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
        public void SavePrice(Price price)
        {
            if (price.PriceID == 0)
            {
                context.Prices.Add(price);
            }
            else
            {
                Price dbEntry = context.Prices.Find(price.PriceID);
                if (dbEntry != null)
                {
                    dbEntry.ProductID = price.ProductID;
                    dbEntry.Date_From = price.Date_From;
                    dbEntry.Product_Price = price.Product_Price;
                    dbEntry.Default_Price = price.Default_Price;
                }
            }
            context.SaveChanges();
        }

        public Price DeletePrice(int id)
        {
            Price priceToDelete = context.Prices.Find(id);
            if (priceToDelete != null)
            {
                context.Prices.Remove(priceToDelete);
            }

            return priceToDelete;
        }
    }
}
