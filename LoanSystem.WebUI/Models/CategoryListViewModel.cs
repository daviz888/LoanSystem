using LoanSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanSystem.WebUI.Models
{
    public class CategoryListViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        //public string CurrentSearch { get; set; }
        //public PagingInfo PagingInfo { get; set; }
        
    }
}