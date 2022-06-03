using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models.Shopping
{
    public class VmCategory
    {
        public int Id { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required( ErrorMessage ="Şöbə adı vacibdir")]
        [MaxLength(50,ErrorMessage ="Şöbə adı maximum 50 xarakter olmalıdır")]
        public string Name { get; set; }
        public string Logo { get; set; }
    }
}
