using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public abstract class BaseEntity
    { 
        public int Id { get; set; }
        [MaxLength(50)]
        public bool Status{ get; set; }
        [MaxLength(50)]
        public DateTime AddedDate { get; set; }
        [MaxLength(50)]
        public DateTime ModifiedDate { get; set; }
        [MaxLength(50)]
        public string AddedBy { get; set; }
       [MaxLength(50)]
        public string ModifiedBy { get; set; }

    }
}
