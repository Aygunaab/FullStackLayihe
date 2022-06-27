using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class TeamMemberViewModel
    {
        public int Id { get; set; }
        public bool Status { get; set; }

        [Required, MaxLength(50)]
        public string FullName { get; set; }
        [Required, MaxLength(50)]
        public string Profession { get; set; }
        public ICollection<TeamMemberSocial> Socials { get; set; }
        public string Image { get; set; }
    }
}
