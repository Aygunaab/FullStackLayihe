using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class RegisterViewModel
    {
        [Required (ErrorMessage ="Ad və Soyad vacibdir")]
        [MaxLength(100,ErrorMessage ="Ad və Soyad maximum 100 xarakter olmalıdır")]
        public string FullName { get; set; }
        [Required(ErrorMessage ="Username vacibdir")]
        [MaxLength(ErrorMessage ="Username maximum 20 xarakter olmalıdır")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "E-poçt vacibdir")]
        [EmailAddress(ErrorMessage = "Düzgün e-poçt daxil edin")]
        public string Email { get; set; }
        [Required (ErrorMessage ="Şifrə vacibdir")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifrə təsdiqi vacibdir")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Şifrə və Şifrə təsdiqi eyni olmalıdır")]
        public string ConfirmPassword { get; set; }
        public sbyte Token { get; set; }

    }
}
