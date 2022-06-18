using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
    public class Subscribe
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Email { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
