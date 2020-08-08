using LoanSystem.Domain.Abstract;
using LoanSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSystem.Domain.Concrete
{
    public class EFInterestRepository : IInterestRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Interest> Interests
        {
            get { return context.Interests; }
        }

        public void SaveInterest(Interest interest)
        {
            if (interest.InterestID == 0)
            {
                context.Interests.Add(interest);
            }
            else
            {
                Interest interestToUpdate = context.Interests.Find(interest.InterestID);
                if (interestToUpdate != null)
                {
                    interestToUpdate.InterestRate = interest.InterestRate;
                    interestToUpdate.InterestYear = interest.InterestYear;
                }
            }
            context.SaveChanges();
        }

        public Interest DeleteInterest(int id)
        {
            Interest dbEntry = context.Interests.Find(id);
            if (dbEntry != null)
            {
                context.Interests.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }            
    }
}
