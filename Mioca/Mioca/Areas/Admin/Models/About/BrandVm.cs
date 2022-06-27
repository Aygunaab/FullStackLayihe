using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models.About
{
    public class BrandVm
    {
        public int Id { get; set; }
        public bool Status { get; set;}
        [Required(ErrorMessage = "Bos ola bilmez")]
        public string Icon { get; set; }
        [Required(ErrorMessage = "Boş olmamalıdır")]
        public IFormFile ImageFile { get; set; }
    }
}
