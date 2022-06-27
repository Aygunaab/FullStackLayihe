using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class FagViewModel:BaseViewModel
    {
        public IEnumerable<Fag> Fags { get; set; }
    }
}
