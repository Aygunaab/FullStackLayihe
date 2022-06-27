using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models
{
    public class SaleItemViewModel
    {
        public bool Status { get; set; }
        public int SaleId { get; set; }
        public SaleViewmodel Sale { get; set; }
        public int ProductId { get; set; }
        public VmProduct Product { get; set;}
        public decimal Quantity { get; set; } 
        public decimal Price { get; set; }
    }
}
