using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models
{
    public class VmProductPhotos
    {
        public int OrderBy { get; set; }
        public int ProductId { get; set; }
        public string Image { get; set; }
    }
}
