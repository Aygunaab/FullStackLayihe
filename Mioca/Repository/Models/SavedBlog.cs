using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
   public  class SavedBlog:BaseEntity
    {
       
        [ForeignKey("Blog")]
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

       
    }
}
