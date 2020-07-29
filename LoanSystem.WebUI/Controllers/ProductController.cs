using LoanSystem.Domain.Abstract;
using LoanSystem.Domain.Entities;
using LoanSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanSystem.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public int PageSize = 10;

        public ProductController(IProductRepository repo)
        {
            this.repository = repo;
        }
              
        public ViewResult List(int? SelectedCategory, int page=1)
        {
            var categories = repository.Categories.OrderBy(c => c.Name);
            ViewBag.SelectedCategory = new SelectList(categories, "CategoryID", "Name", SelectedCategory);
            int categoryID = SelectedCategory.GetValueOrDefault();
            //ViewBag.CurrentFilter = searchString;

            ProductListViewModel model = new ProductListViewModel
            {
                Products = repository.Products
                    .Where(c => !SelectedCategory.HasValue || c.CategoryID == categoryID)
                    .OrderBy(p => p.Name)                    
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = SelectedCategory == null ?
                        repository.Products.Count() :
                        repository.Products.Where(p => p.CategoryID == SelectedCategory).Count()
                },
                CurrentCategory = SelectedCategory,               
            };

            return View(model);
        }

        public ViewResult Create()
        {
            ViewBag.ProductAction = "Create Product";
            PopulateCategoryDropDownList();
            return View("Update", new Product());
        }

        private void PopulateCategoryDropDownList(object selectedCategory = null)
        {
            var categories = repository.Categories.OrderBy(c => c.Name);
            ViewBag.CategoryID = new SelectList(categories, "CategoryID", "Name", selectedCategory);
        }

        public ViewResult Update(int productID)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID);
            PopulateCategoryDropDownList(product.CategoryID);
            return View(product);

        }

        [HttpPost]
        public ActionResult Update(Product product, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} successfully updated.", product.Name);
                return RedirectToAction("List");
            }
            else
            {
                TempData["message"] = string.Format("An error encountered while updating {0}", product.Name);
                return View(product);
            }

        }

        public ActionResult Delete(int productID)
        {
            Product deleteProduct = repository.DeleteProduct(productID);

            if (deleteProduct != null)
            {
                TempData["message"] = string.Format("{0} Successfully deleted...", deleteProduct.Name);

            }
            return RedirectToAction("List");
        }

        public FileContentResult GetImage(int productID)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productID);

            if (prod != null && prod.ImageData != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
                
        }
    }
}