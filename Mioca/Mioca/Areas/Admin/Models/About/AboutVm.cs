using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models.About
{
    public class AboutVm
    {
        public IEnumerable<OurMissionVm> Missions { get; set; }
        public IEnumerable<TeamMemberVm> TeamMembers { get; set; }
        public IEnumerable<WhatClientSaysVm> whatClientSays { get; set; }
        public IEnumerable<BrandVm> Brands { get; set; }
    }
}
