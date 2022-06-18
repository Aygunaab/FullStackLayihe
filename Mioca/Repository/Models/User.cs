using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
   public  class User:IdentityUser
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(250)]
        public string State { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(250)]
        public string ZipCode { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }
        public bool IsActive { get;  set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
        public bool HasAccount { get; set; }
        public ICollection<ProductReview> Reviews { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public List<Sale> Sales { get; set; }
        public string Company { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
