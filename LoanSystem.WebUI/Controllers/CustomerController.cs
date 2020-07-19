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

        public int PageSize = 4;
        
        public CustomerController(ICustomerRepository custRepo)
        {
            repository = custRepo;
        }
        public ViewResult CustomerList()
        {
            CustomerListViewModel model = new CustomerListViewModel
            {
                Customers = repository.Customers
                 .OrderBy(c => c.LastName)
                 .ThenBy(c => c.FirstName)
            };
            return View(model);
        }
    }
}