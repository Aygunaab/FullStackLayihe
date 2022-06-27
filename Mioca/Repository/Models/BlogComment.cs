using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
    public class BlogComment:BaseEntity
    {

        public int BlogId { get; set; }
        public string UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(500)]
        public string Mesage { get; set; }
        public User User { get; set; }
        public Blog Blog { get; set; }



    }
}
