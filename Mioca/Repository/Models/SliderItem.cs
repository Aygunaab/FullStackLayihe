using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public  class SliderItem:BaseEntity
    {
        [Required]
        public int OrderBy { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        [Required]
        [MaxLength(20)]
        public string Subtitle { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
       
        [MaxLength(50)]
        public string ActionText { get; set; }
        [MaxLength(200)]
        public string Endpoint { get; set; }
        [Required]
        [MaxLength(100)]
        public string Image { get; set; }

    }
}
