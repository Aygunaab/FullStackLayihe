using System.ComponentModel.DataAnnotations;


namespace Repository.Models
{
    public class WhatClientSays:BaseEntity
    {
       
     
        [Required, MaxLength(150)]
        public string ClientImage { get; set; }
        [Required, MaxLength(500)]
        public string ClientComment { get; set; }
        [Required, MaxLength(30)]
        public string FullName { get; set; }
        [Required, MaxLength(20)]
        public string companyName { get; set; }
    }
}
