using LoanSystem.Domain.Entities;
using System.Collections.Generic;

namespace LoanSystem.Domain.Abstract
{
    public interface IPriceRepository
    {
        IEnumerable<Price> Prices { get; }
        void SavePrice(Price price);
        Price DeletePrice(int Id);

    }
}
