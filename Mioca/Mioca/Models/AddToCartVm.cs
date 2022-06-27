using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class AddToCartVm:BaseViewModel
    {
        public IEnumerable<BasketViewModel> Products { get; set; }
        public Tax Tax { get; set; }
    }
}
