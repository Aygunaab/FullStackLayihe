using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
    public class BlogTag:BaseEntity
    {
       [MaxLength(30, ErrorMessage = "Maksimum 30 charakter daxil edə bilərsiniz"), Required(ErrorMessage = "Ad boş olmamalıdır!")]
        public string Name { get; set; }
        public List<TagToBlog> TagToBlogs { get; set; }
    }
}
