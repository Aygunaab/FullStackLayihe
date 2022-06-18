using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class VmUserNotRegister
    {
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Surname { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        [Required]
        public int CountryId { get; set; }
        [MaxLength(250)]
        public string State { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
        [MaxLength(10)]
        public string Zipcode { get; set; }
        [MaxLength(250)]
        public string Company { get; set; }

        [MaxLength(250)]
        public string Password { get; set; }

        [MaxLength(250)]
        public string ConfirmPassword { get; set; }
        public bool CreateAccount { get; set; }


        //Properties for Card info
        [MaxLength(250), Required]
        public string CardName { get; set; }

        [MaxLength(16), Required]
        public string CardNumber { get; set; }

        [MaxLength(3), Required]
        public string SecurityCode { get; set; }

        [MaxLength(5), Required]
        public string CardDate { get; set; }

        public List<ChecoutViewModel> SaleProduts { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ShippingPrice { get;  set; }
        public int TypeId { get; internal set; }
        public int Quantity { get; internal set; }
     
    }
}
