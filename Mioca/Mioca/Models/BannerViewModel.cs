using Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class BannerViewModel
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ActionText { get; set; }
        public string EndPoint { get; set; }
        public string Image { get; set; }
        public BannerCardWidth CardWidth { get; set; }
    }
}
