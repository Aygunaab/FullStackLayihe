using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class SaleVm:BaseViewModel
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime AddedDate { get; set; }
        public List<SaleItem> SaleItems { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
