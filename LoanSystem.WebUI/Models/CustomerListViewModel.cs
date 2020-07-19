using LoanSystem.Domain.Entities;
using System.Collections.Generic;


namespace LoanSystem.WebUI.Models
{
    public class CustomerListViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}