using Microsoft.AspNetCore.Http;
using Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models
{
    public class BannerVm
    {

        public int Id { get; set; }
        public string Category { get; set; }
        public bool Status { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        
        public string ActionText { get; set; }
       
        public string EndPoint { get; set; }
        public bool IsTopBanner { get; set; }
        public bool IsBottomBanner { get; set; }
        public DateTime AddedDate { get; set; }
        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }
        public BannerCardWidth CardWidth { get; set; }
        
    }
}
