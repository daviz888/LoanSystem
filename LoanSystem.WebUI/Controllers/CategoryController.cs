using LoanSystem.Domain.Abstract;
using LoanSystem.Domain.Entities;
using LoanSystem.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace LoanSystem.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository repository;

        public CategoryController(ICategoryRepository repo)
        {
            this.repository = repo;
        }
        public ViewResult Index(string searchString="")
        {
            CategoryListViewModel model = new CategoryListViewModel
            {
                Categories = repository.Categories
                    .Where(c => c.Name.Contains(searchString))
                    .OrderBy(c => c.CategoryID)
            };
                
            return View(model);
        }

        public ViewResult Create()
        {
            return View("Create", new Category());
        }
    }
}