using Microsoft.AspNetCore.Http;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models.About
{
    public class TeamMemberVm
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public string FullName { get; set; }
        [Required, MaxLength(50)]
        public string Profession { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Boş olmamalıdır")]
        public IFormFile ImageFile { get; set; }
    }
}
