using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class AboutViewModel
    {
        public OurMission Missions { get; set; }
        public ICollection<TeamMember> TeamMembers { get; set; }
        public ICollection<WhatClientSays> whatClientSays { get; set; }
        public ICollection<Brand> Brands { get; set; }
    }
}
