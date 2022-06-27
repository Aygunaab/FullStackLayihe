using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models.About
{
    public class OurMissionVm
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime AddedDate { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required, MaxLength(5000)]
        public string Desc { get; set; }
        [Required, MaxLength(250)]
        public string Videolink { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Boş olmamalıdır")]
        public IFormFile ImageFile{ get; set; }
    }
}
