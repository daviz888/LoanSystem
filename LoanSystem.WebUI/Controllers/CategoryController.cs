using LoanSystem.Domain.Abstract;
using LoanSystem.Domain.Entities;
using LoanSystem.WebUI.Models;
using Microsoft.Ajax.Utilities;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
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

        public ActionResult Create()
        {
            return View("Create", new Category());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Remarks")]Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.SaveCategory(category);
                    TempData["message"] = string.Format("Category: {0} successfully Added.", category.Name);
                    return RedirectToAction("Index");

                }
            }
            catch (RetryLimitExceededException dex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", dex);
                TempData["message"] = "Unable to save changes. Try again, and if the problem persists, see your system administrator";

            }
            return View(category);
        }

        public ActionResult Edit(int? categoryID)
        {
            if (categoryID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = repository.Categories.FirstOrDefault(c => c.CategoryID == categoryID);

            return View(category);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditItem(int? CategoryID)
        {
            if (CategoryID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                Category categoryToUpdate = repository.Categories.FirstOrDefault(c => c.CategoryID == CategoryID);
            if (TryUpdateModel(categoryToUpdate, "", 
               new string[] { "Name", "Remarks" }))
            {
                try
                {
                    repository.SaveCategory(categoryToUpdate);
                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException dex)
                {
                    ModelState.AddModelError("", dex);
                    TempData["message"] = "Unable to save changes. Try again, and if the problem persists, see your system administrator";
                }
            }

            return View(categoryToUpdate);
        }

        public ActionResult Delete(int? categoryId)
        {
            if (categoryId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category model = repository.Categories.FirstOrDefault(c => c.CategoryID == categoryId);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);

        }

        [HttpPost, ActionName("delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int categoryID)
        {
            Category categoryToDelete = repository.DeleteCategory(categoryID);
            if (categoryToDelete != null)
            {
                TempData["message"] = string.Format("{0} Successfully deleted...", categoryToDelete.Name);
            }
            return RedirectToAction("Index");
        }

    }
}