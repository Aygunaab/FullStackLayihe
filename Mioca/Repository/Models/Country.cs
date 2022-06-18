using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
   public class Country
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string City { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N3}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ShippingPrice { get; set; }

        public List<User> Users { get; set; }
    }
}
