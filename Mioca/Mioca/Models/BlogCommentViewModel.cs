using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class BlogCommentViewModel:BaseViewModel
    {
        public Blog Blog { get; set; }
        public BlogReviewModel Review { get; set; }
        public List<BlogCategory> Categories { get; set; }
        public List<Blog> Blogs { get; set; }

    }
}
