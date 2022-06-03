using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class ReviewViewModel
    {
        public DateTime AddedDate { get; set; }
       
        public DateTime ModifiedDate { get; set; }
        public byte Ratings { get; set; }
        public string Subject { get; set; }
        public string Mesage { get; set; }
        public UserViewModel User{ get; set; }
    }
}
