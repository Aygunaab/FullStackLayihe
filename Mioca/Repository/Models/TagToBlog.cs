using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
   public class TagToBlog
    {
       
        public int Id { get; set; }
        [ForeignKey("Blog")]
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public BlogTag Tag { get; set; }
    }
}
