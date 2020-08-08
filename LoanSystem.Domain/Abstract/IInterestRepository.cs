using LoanSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSystem.Domain.Abstract
{
    public interface IInterestRepository
    {
        IEnumerable<Interest> Interests { get; }
        void SaveInterest(Interest interest);
        Interest DeleteInterest(int id);

    }
}
