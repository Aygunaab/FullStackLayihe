using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Repository.Models
{
  public  class TeamMember:BaseEntity
    {
       
        [Required, MaxLength(150)]
        public string Image { get; set; }
        [Required, MaxLength(50)]
        public string FullName { get; set; }
        [Required, MaxLength(50)]
        public string Profession { get; set; }
        public ICollection<TeamMemberSocial> Socials { get; set; }

    }
}
