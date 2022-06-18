using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
    public class Social:BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Icon { get; set; }
        [Required]
        [MaxLength(200)]
        public string Link { get; set; }
        public ICollection<ProductSocial> Products { get; set; }
        public ICollection<TeamMemberSocial> TeamMembers { get; set; }

    }
}
