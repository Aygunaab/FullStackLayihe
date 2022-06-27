using Repository.Enums;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class BlogVm:BaseViewModel
    {
        public Blog Blog { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Blog> RecentPost { get; set; }
        public List<BlogCategory> Categories { get; set; }
        public List<BlogComment> Comments { get; set; }
        public BlogComment Comment { get; set; }
        public List<BlogTag> Tags { get; set; }
     
        public BlogVm Filter { get; set; }
        public int? catId { get; set; }

    }
}
