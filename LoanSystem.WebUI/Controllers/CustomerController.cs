using System;
using System.Collections.Generic;
using System.Linq;
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

        public int PageSize = 15;
        
        public CustomerController(ICustomerRepository custRepo)
        {
            this.repository = custRepo;
        }
        public ViewResult CustomerList(int page = 1)
        {
            CustomerListViewModel model = new CustomerListViewModel
            {
                Customers = repository.Customers
                 .OrderBy(c => c.LastName)
                 .ThenBy(c => c.FirstName)
                 .Skip((page - 1) * PageSize)
                 .Take(PageSize),
                PagingInfo = new PagingInfo
                { 
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Customers.Count()
                    },
            };
            return View(model);
        }

        public ViewResult Edit(int customerID)
        {
            Customer customer = repository.Customers
                .FirstOrDefault(c => c.CustomerID == customerID);

            return View(customer);
        }

        public ActionResult Delete(int customerId)
        {
            Customer deleteCustomer = repository.DeleteCustomer(customerId);
            if (deleteCustomer != null)
            {
                TempData["message"] = string.Format("Customer: {0} : {1}, {2} was deleted.",
                    deleteCustomer.CustomerID, deleteCustomer.LastName, deleteCustomer.FirstName);
            }
            return RedirectToAction("CustomerList");
        }

    }
}