using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSystem.Domain.Entities
{
    public class Price
    {
        public int PriceID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        [Display(Name = "Applicable Date")]
        public DateTime Date_From { get; set; }
        [Required]
        [Display(Name ="Product Name")]
        public int ProductID { get; set; }

        [Display(Name ="Price")]
        public decimal Product_Price { get; set; }

        [Required]
        [Display(Name = "Default Price")]
        public bool Default_Price { get; set; } = false;

        public virtual Product Products { get; set; }
    }
}
