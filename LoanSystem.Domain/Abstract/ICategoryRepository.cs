using LoanSystem.Domain.Entities;
using System.Collections.Generic;

namespace LoanSystem.Domain.Abstract
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
        void SaveCategory(Category category);
        Category DeleteCategory(int categoryId);

    }
}
