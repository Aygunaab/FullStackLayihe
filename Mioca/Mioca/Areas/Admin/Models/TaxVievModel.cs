using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models
{
    public class TaxVievModel
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public decimal PriceLimit { get; set; }

        public decimal Percent { get; set; }
    }
}
