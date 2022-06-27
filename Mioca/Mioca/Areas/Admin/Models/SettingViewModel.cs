using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models
{
    public class SettingViewModel
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public string Logo { get; set; }
        [Required(ErrorMessage = "Boş olmamalıdır")]
        public IFormFile LogoFile { get; set; }
        public string Number { get; set; }
        public string Adress { get; set; }    
        public string Phone { get; set; }     
        public string Email { get; set; }
    }
}
