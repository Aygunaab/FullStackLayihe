using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class ContactMessage
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Ad vacibdir")]

        [MaxLength(250)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad vacibdir")]

        [MaxLength(250)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Email vacibdir")]

        [MaxLength(250)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Mesaj vacibdir")]

        [MaxLength(500)]
        public string Message { get; set; }
    }
}
