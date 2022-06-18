using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
   public class SaleItem:BaseEntity
    {
       
        [ForeignKey("Sale")]
        public int SaleId { get; set; }
        public Sale Sale { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Column(TypeName = "money"), Required]
        public decimal Quantity { get; set; }
        [Column(TypeName = "money"), Required]
        public decimal Price { get; set; }
    }
}
