using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models
{
    public class FagVm
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Boş olmamalıdır")]
        public string Question { get; set; }
        [Required(ErrorMessage = "Boş olmamalıdır")]
        public string Answer { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Status { get; set; }
    }
}
