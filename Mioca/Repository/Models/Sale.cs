using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
   public class Sale:BaseEntity
    {
      
        [MaxLength(15)]
        public string InvoiceNo { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        public List<SaleItem> SaleItems { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ShippingPrice { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
       
    }
}
