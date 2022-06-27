using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class BlogReviewModel
    {
        public DateTime AddedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string Subject { get; set; }
        [Required, MaxLength(500)]
        public string Mesage { get; set; }
        public UserViewModel User { get; set; }
    }
}
