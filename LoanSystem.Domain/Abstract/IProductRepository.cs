using LoanSystem.Domain.Entities;
using System.Collections.Generic;

namespace LoanSystem.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Product { get; set; }

        void SaveProduct(Product product);
        Product DeleteProduct(int productID);


    }
}
