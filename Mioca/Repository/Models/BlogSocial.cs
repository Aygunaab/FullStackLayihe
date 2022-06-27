using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    public class BlogSocial
    {

        public int Id { get; set; }
        public int SocialId { get; set; }
        public int BlogId { get; set; }
        public Social Social { get; set; }
        public Blog Blog { get; set; }
        public string Link { get; set; }
      
    }
}
