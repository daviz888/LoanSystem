using System;
using System.ComponentModel.DataAnnotations;

namespace LoanSystem.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public DateTime Date_Time { get; set; } = DateTime.Today;
        public int CategoryID { get; set; }

        public virtual Category Category {get; set;}
    }
}
