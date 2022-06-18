using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models
{
    public class HomeVm
    {
        public IEnumerable<SliderVm> Slider { get; set; }
        public IEnumerable<BannerVm> Banner { get; set; }
    }
}
