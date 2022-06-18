using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models
{
    public class SliderVm
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string ActionText { get; set; }
        public string Endpoint { get; set; }
        public string Image { get; set; }
        public IFormFile ImageFile { get;  set; }
    }
}
