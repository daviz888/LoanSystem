using LoanSystem.Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace LoanSystem.WebUI.Models
{
    public class PriceListViewModel
    {
        public IEnumerable<Price> Prices { get; set; }

        //public IEnumerable<Product> Products { get; set; }
       
    }
}