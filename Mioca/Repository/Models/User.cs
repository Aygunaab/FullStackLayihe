using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public  class User:IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProfilImage { get; set; }
        public ICollection<ProductReview> Reviews { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
    }
}
