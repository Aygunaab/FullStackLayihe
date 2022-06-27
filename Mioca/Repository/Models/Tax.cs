using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models
{
   public  class Tax:BaseEntity
    {

        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceLimit { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Percent { get; set; }
    }
}
