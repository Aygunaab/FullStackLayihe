using Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class BlogListViewModel
    {
        public BlogCategoryViewModel Category { get; set; }
        public IEnumerable<BlogVm> Blogs;
        public int Count { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }

    public class BlogCategorySearchViewModel
    {
        public BlogCategorySearchViewModel()
        {
            Page = 1;
            Limit = 6;

        }
        public int Id { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
     


    }
}

