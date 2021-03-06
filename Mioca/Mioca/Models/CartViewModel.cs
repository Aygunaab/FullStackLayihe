using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public IList<string> Photos { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? Quantity { get; set; }
    }
}
