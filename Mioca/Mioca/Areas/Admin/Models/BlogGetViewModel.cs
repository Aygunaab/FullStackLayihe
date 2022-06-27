using Microsoft.AspNetCore.Http;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models
{
    public class BlogGetViewModel
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime AddedDate { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }
        public string TextTopQuote { get; set; }
        public string TextBottomQuote { get; set; }
        public string SloganUser { get; set; }
        public int CategoryId { get; set; }
        public BlogCategory Category { get; set; }
       
    }
}
