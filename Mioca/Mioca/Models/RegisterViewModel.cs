using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username vacibdir")]
        [MaxLength( 20,ErrorMessage = "Username maximum 20 xarakter olmalıdır")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Ad vacibdir")]
        [MaxLength( 50,ErrorMessage = "Ad maximum 50 xarakter olmalıdır")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad vacibdir")]
        [MaxLength(50, ErrorMessage = "Soyad maximum 50 xarakter olmalıdır")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "E-poçt vacibdir")]
        [EmailAddress(ErrorMessage = "Düzgün e-poçt daxil edin")]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrə vacibdir")]
        [DataType(DataType.Password)]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifrə təsdiqi vacibdir")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Şifrə və Şifrə təsdiqi eyni olmalıdır")]
        [MaxLength(30)]
        public string ConfirmPassword { get; set; }

    }
}
