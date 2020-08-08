using LoanSystem.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LoanSystem.Domain.Abstract
{
    public interface IPriceRepository
    {
        //IEnumerable<Price> Prices { get; }
        IQueryable<Price> Prices { get; }

        IEnumerable<Product> Products { get;}
        void SavePrice(Price price);
        Price DeletePrice(int Id);

    }
}
