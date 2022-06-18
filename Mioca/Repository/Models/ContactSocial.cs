using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
  public class ContactSocial
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Link { get; set; }
        public string Icon { get; set; }
       
        public Contact Contact { get; set; }
       
    }
}
