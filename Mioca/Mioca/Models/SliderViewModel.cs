using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class SliderViewModel
    {
 
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string ActionText { get; set; }
        public string Endpoint { get; set; }
        public string Image { get; set; }
    }
}
