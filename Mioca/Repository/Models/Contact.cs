using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public  class Contact
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string Phone { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Desc { get; set; }

        [MaxLength(4000)]
        public string Map { get; set; }
        public IEnumerable<ContactSocial> Socials { get; set; }

    }
}
