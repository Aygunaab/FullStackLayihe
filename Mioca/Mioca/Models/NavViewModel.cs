using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class NavViewModel
    {
        public Setting Setting { get; set; }
        public List<BasketViewModel>Basket { get; set; }
    }
}
