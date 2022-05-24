using Repository.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
  public class Banner:BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string  Category { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string SubTitle { get; set; }
        [MaxLength(50)]
        public string ActionText { get; set; }
        [MaxLength(200)]
        public string EndPoint { get; set; }
        [Required]
        [MaxLength(100)]
        public string Image { get; set; }
        public BannerCardWidth CardWidth { get; set; }


    }
}
