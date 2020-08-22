using LoanSystem.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSystem.Domain.Entities
{
    public class Cart
    {
        private List<ProductLine> productCollection = new List<ProductLine>();
        private EFPriceRepository priceRepository;

        public void AddItem(Product product, int priceID, int quantity)
        {

            ProductLine line = productCollection
                .Where(p => p.Product.ProductID == product.ProductID)                   
                .FirstOrDefault();

            if (line == null)
            {
                productCollection.Add(new ProductLine
                {
                    Product = product,
                    PriceID = priceID,
                    Price = priceRepository.getPrice(priceID),
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
       
        }

        public void RemoveItem(Product product)
        {
            productCollection.RemoveAll(p => p.Product.ProductID == product.ProductID);
        }

        public decimal ComputeTotal()
        {
            return productCollection.Sum(p => p.Price * p.Quantity);
        }

        public void Clear()
        {
            productCollection.Clear();
        }
        public IEnumerable<ProductLine> Lines
        {
            get { return productCollection; }
        }
    }

    public class ProductLine
    {
        public Product Product { get; set; }

        public int PriceID { get; set; }

        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
