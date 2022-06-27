using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class ProductViewModel:BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime AddedDate { get; set; }
        public decimal? DiscountPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Count { get; set; } = 1;
        public byte StarCount { get; set; }
        public string Avability { get; set; }
        public string Text { get; set; }
        public string MainImage { get; set; }
        public string Description { get; set; }
        public IList<string>Photos { get; set; }
        public LabelViewModel Label { get; set; }
        public DiscountViewModel Discount { get; set; }
        public CategoryViewModel Category { get; set; }
        public ICollection<ProductSocial> Socials { get; set; }
        public ICollection<ProductSpecsification> Specs { get; set; }
        public ICollection<ReviewViewModel> Reviews { get; set; }
        public ReviewViewModel Review { get; set; }
        public Product Product { get; set; }
    }
}
