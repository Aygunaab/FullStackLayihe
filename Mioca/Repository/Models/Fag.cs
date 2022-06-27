using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
   public class Fag:BaseEntity
    {

        [MaxLength(250)]
        public string Question { get; set; }

        [MaxLength(2000)]
        public string Answer { get; set; }

        public bool IsGeneral { get; set; }
    }
}
