using Microsoft.AspNetCore.Http;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class ProfileViewModel:BaseViewModel
    {
        public string Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(250)]
        public string Roles { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }

        [MaxLength(250)]
        public string Password { get; set; }

        [Required, MaxLength(250)]
        public string State { get; set; }

        [Required, MaxLength(20)]
        public string Phone { get; set; }

        [Required, MaxLength(10)]
        public string Zipcode { get; set; }

        [Required]
        public int? CountryId { get; set; }
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string Image { get; set; }

        public string Country { get; set; }

        public string Adress { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
