using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class basketVm
    {
        public Product Product { get; set; }
        public int Count { get; set; } = 1;
        public decimal MaxQuantity { get; set; }
    }
}
