using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class WishViewModel
    {
        public int ProductId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string Date { get; set; }
        
    }
}
