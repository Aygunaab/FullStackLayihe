using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models.About
{
    public class WhatClientSaysVm
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime AddedDate { get; set; }

        [Required, MaxLength(500)]
        public string ClientComment { get; set; }
        [Required, MaxLength(30)]
        public string FullName { get; set; }
        [Required, MaxLength(20)]
        public string companyName { get; set; }
        public string ClientImage { get; set; }
        [Required(ErrorMessage = "Boş olmamalıdır")]
        public IFormFile ClientImageFile { get; set; }
    }
}
