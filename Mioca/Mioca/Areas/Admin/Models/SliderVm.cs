using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models
{
    public class SliderVm
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        [Required(ErrorMessage ="Başlıq boş olmamalıdır")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Qısa mətn boş olmamalıdır")]
        public string Subtitle { get; set; }
        [Required(ErrorMessage = "Qiymət boş olmamalıdır")]
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string ActionText { get; set; }
        public string Endpoint { get; set; }
        [Required(ErrorMessage = "Şəkil boş olmamalıdır")]
        public string Image { get; set; }
        public IFormFile ImageFile { get;  set; }
    }
}
