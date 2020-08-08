using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSystem.Domain.Entities
{
    public class Interest
    {        
        public int InterestID { get; set; }
        [Required]
        [Display(Name ="Interest Rate")]        
        public decimal InterestRate { get; set; }
        [Required]
        [Display(Name ="Applicable Year")]
        public int InterestYear { get; set; }
    }
}
