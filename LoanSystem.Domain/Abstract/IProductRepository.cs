using LoanSystem.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LoanSystem.Domain.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get;}
        void SaveProduct(Product product);
        Product DeleteProduct(int productID);

        IEnumerable<Category> Categories { get; }      

    }
}
