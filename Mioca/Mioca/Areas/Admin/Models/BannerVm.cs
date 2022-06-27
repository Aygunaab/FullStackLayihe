using Microsoft.AspNetCore.Http;
using Repository.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models
{
    public class BannerVm
    {

        public int Id { get; set; }
        public string Category { get; set; }
        public bool Status { get; set; }
        [Required(ErrorMessage = "Başlıq boş olmamalıdır")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Boş olmamalıdır")]
        public string SubTitle { get; set; }
        
        public string ActionText { get; set; }
       
        public string EndPoint { get; set; }
        public bool IsTopBanner { get; set; }
        public bool IsBottomBanner { get; set; }
        public DateTime AddedDate { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Şəkil boş olmamalıdır")]
        public IFormFile ImageFile { get; set; }
        public BannerCardWidth CardWidth { get; set; }
        
    }
}
