using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class BasketViewModel
    {
        public int Id { get; set; }
        public string MainImage { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Count { get; set; }
        public decimal MaxQuantity { get; set; }
        public DiscountViewModel Discount { get; set; }
    }

   
}
