using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class CommentViewModel
    {
        public ProductViewModel Product { get; set; }
        public ReviewViewModel Review { get; set; }
    }
}
