using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
    public class ProductSpecsification:BaseEntity
    {
        [Required]
        public int OrderBy { get; set; }
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Key { get; set; }
        [Required]
        [MaxLength(500)]
        public string Value { get; set; }

    }
}
