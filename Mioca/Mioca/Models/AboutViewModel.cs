using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    public class AboutViewModel:BaseViewModel
    {
        public IEnumerable<OurMission> Missions { get; set; }
        public IEnumerable<TeamMemberViewModel> TeamMembers { get; set; }
        public IEnumerable<WhatClientSays> whatClientSays { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
    }
}
