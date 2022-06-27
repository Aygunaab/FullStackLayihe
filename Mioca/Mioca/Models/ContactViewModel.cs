using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class ContactViewModel:BaseViewModel
    {
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Surname { get; set; }

        [MaxLength(250)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }
       [Required, MaxLength(500)]
        public string Message { get; set; }
        public Contact Contact { get; set; }
     
    }
}
