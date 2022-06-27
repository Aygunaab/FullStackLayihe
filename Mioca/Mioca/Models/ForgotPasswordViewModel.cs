using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class ForgotPasswordViewModel:BaseViewModel
    {
        [Required, MaxLength(250)]
        public string Email { get; set; }
    }
}
