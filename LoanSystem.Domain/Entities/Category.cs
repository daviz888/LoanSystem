using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSystem.Domain.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name {get; set;}

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }
    }
}
