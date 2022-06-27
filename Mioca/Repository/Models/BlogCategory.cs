using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
   public  class BlogCategory:BaseEntity
    {
        public string Name { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
