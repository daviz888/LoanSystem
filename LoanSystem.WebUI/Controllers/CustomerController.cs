using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using LoanSystem.Domain.Abstract;
using LoanSystem.Domain.Entities;
using LoanSystem.WebUI.Models;

namespace LoanSystem.WebUI.Controllers
{   
    public class CustomerController : Controller
    {
        private ICustomerRepository repository;

        public int PageSize = 12;
        
        public CustomerController(ICustomerRepository custRepo)
        {
            this.repository = custRepo;
        }
        public ViewResult CustomerList(string searchText = "", int page = 1)
        {
            CustomerListViewModel model = new CustomerListViewModel
            {
                Customers = repository.Customers
                 .Where(c => c.LastName.Contains(searchText.ToUpper()))
                 .OrderBy(c => c.LastName)
                 .ThenBy(c => c.FirstName)
                 .Skip((page - 1) * PageSize)
                 .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = searchText == null ?
                        repository.Customers.Count() :
                        repository.Customers.Where(e => e.LastName.Contains(searchText.ToUpper())).Count()
                },
                CurrentSearch = searchText
            };            
            return View(model);
        }

        public ViewResult Create()
        {
            ViewBag.CustomerAction = "Create New Customer";
            return View("Edit", new Customer());
        }
        public ViewResult Edit(int customerID)
        {
            ViewBag.CustomerAction = "Edit Customer";
            Customer customer = repository.Customers
                .FirstOrDefault(c => c.CustomerID == customerID);

            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCustomer(customer);
                TempData["message"] = string.Format("Customer: {0}, {1} successfully updated.", customer.LastName, customer.FirstName);
                return RedirectToAction("CustomerList");
            }
            else
            {
                // There is something wrong with the data values
                TempData["message"] = string.Format("An error has been encountered while updating customer {0}, {1}.", customer.LastName, customer.FirstName);
                return View(customer);
            }
        }
        public ActionResult Delete(int customerId)
        {
            Customer deleteCustomer = repository.DeleteCustomer(customerId);
            if (deleteCustomer != null)
            {
                TempData["message"] = string.Format("Customer ID: {0} - {1}, {2} was deleted.",
                    deleteCustomer.CustomerID, deleteCustomer.LastName, deleteCustomer.FirstName);
            }
            return RedirectToAction("CustomerList");
        }

    }
}