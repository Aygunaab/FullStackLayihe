using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public  class ProductReview:BaseEntity
    {
        public int ProductId { get; set; }
        public string UserId { get; set; }
        [Required]
        public byte Ratings { get; set; }
        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(500)]
        public string Mesage { get; set; }
        public CustomUser User { get; set; }
        public Product Product { get; set; }

    }
}
