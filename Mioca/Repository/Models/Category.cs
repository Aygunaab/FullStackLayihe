
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Repository.Models
{
   public class Category:BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Logo { get; set; }
        public ICollection<ProductCategory> Products { get; set; }
    }
}
