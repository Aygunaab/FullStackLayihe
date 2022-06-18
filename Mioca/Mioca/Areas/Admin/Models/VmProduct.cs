using Mioca.Areas.Admin.Models.Shopping;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models
{
    public class VmProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public int Quantity { get; set; }
        public int StarCount { get; set; }
        public string Text { get; set; }
        public DateTime AddedDate { get; set; }
        public string Description { get; set; }
        public IList<string> Photos { get; set; }
        public Category Categories { get; set; }


    }
}
