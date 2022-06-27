using Microsoft.AspNetCore.Http;
using Repository.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    public class Blog:BaseEntity
    {
    
        [MaxLength(500), Required(ErrorMessage = "Başlıq boş olmamalıdır!")]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [Column(TypeName = "ntext"), Required(ErrorMessage = "Mətn boş olmamalıdır!")]
        public string TextTopQuote { get; set; }
        [Column(TypeName = "ntext"), Required(ErrorMessage = "Mətn boş olmamalıdır!")]
        public string TextBottomQuote { get; set; }
        [Column(TypeName = "ntext"), Required(ErrorMessage = "Mətn boş olmamalıdır!"),MaxLength(100)]
        public string SloganUser{ get; set; }
     

        [Required(ErrorMessage = "Category Secmelisiniz!")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public BlogCategory Category { get; set; }
        [NotMapped]
        public int[] TagIds { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<BlogComment> Comments { get; set; }
        public ICollection<TagToBlog> TagToBlogs { get; set; }
        public ICollection<BlogSocial> Socials { get; set; }
       

    }
}
