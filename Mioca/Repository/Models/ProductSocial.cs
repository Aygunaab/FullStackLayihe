using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class ProductSocial
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SocialId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Link { get; set; }
        public Product Product { get; set; }
        public Social Social { get; set; }

    }
}
