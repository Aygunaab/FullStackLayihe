using Microsoft.AspNetCore.Http;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models
{
    public class BlogViewModel
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime AddedDate  { get; set; }
        [Required (ErrorMessage ="Ad vacibdir")]
        public string Title { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Boş olmamalıdır")]
        public IFormFile ImageFile { get; set; }
        [Required(ErrorMessage = "Boş olmamalıdır")]
        public string TextTopQuote { get; set; }
        [Required(ErrorMessage = "Boş olmamalıdır")]
        public string TextBottomQuote { get; set; }
        [Required(ErrorMessage = "Boş olmamalıdır")]
        public string SloganUser { get; set; }
        public int CategoryId { get; set; }
        public List<BlogCategory> Category { get; set; }
        public int[] TagIds { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<TagToBlog> TagToBlogs { get; set; }

    }

}
