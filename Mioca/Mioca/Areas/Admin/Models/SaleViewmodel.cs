using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models
{
    public class SaleViewmodel
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public string InvoiceNo { get; set; }
        public decimal Tax { get; set; }
        public string ShippingCountry { get; set; }

        public decimal ShippingPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public User User { get; set; }
        public Country Country { get; set; }
        public DateTime Date { get; set; }
        public SaleItem Item { get; set; }
       
    }
}
