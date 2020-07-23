using LoanSystem.Domain.Entities;
using System.Collections.Generic;

namespace LoanSystem.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get;}
        void SaveProduct(Product product);
        Product DeleteProduct(int productID);

        IEnumerable<Category> Categories { get; }

    }
}
