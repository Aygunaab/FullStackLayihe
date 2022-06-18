using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class ReviewViewModel
    {
        public DateTime AddedDate { get; set; }
       
        public DateTime ModifiedDate { get; set; }
        [Required]
        [Range(1,5)]
        public byte Ratings { get; set; }

        public string Subject { get; set; }
        [Required,MaxLength(500)]
        public string Mesage { get; set; }
        public UserViewModel User{ get; set; }
    }
}
