
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public class Product:BaseEntity
    {
        public int Categoryid { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [Column(TypeName="ntext")]
        public string Text { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        [Required]
        public string Avability { get; set; }
        public int? LabelId { get; set; }
        public Label Label { get; set; }
        [Required]
        public bool IsPopularCategory { get; set; }
        [Required]
        public bool IsBestSeellers{ get; set; }
        public byte StarCount { get; set; }
        public ICollection<ProductPhoto> Photos { get; set; }
        public ICollection<ProductReview> Reviews { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductSocial> Socials { get; set; }
        public ICollection<ProductDiscount> Discounts { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Basket> Baskets { get; set; }
    }
}
