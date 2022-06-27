using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.AdminRepositories
{
    public interface IAboutRepository
    {
        IEnumerable<OurMission> GetMission();
        IEnumerable<TeamMember> GetTeamMember();
        IEnumerable<WhatClientSays> GetWhatSays();
        IEnumerable<Brand> GetBrands();
        void CreateMission(OurMission mission);
        void UpdateMission(OurMission mission);
        OurMission GetMissionById(int id);
        void DeleteMission(OurMission mission);
        WhatClientSays GetWhatSaysById(int id);
        void CreateComment(WhatClientSays comment);
        void UpdateComment(WhatClientSays comment);
        void DeleteComment(WhatClientSays comment);
        TeamMember GetTeamMemberById(int id);
        void UpdateTeamMember(TeamMember member);
        void CreateTeamMember(TeamMember member);
        void DeleteTeamMember(TeamMember member);
        Brand GetBrandById(int id);
        void CreateBrand(Brand brand);
        void DeleteBrand(Brand brand);
        void UpdateBrand(Brand brand);
    }
    public class AboutRepository : IAboutRepository
    {
        private readonly MiocaDbContext _context;

        public AboutRepository(MiocaDbContext context)
        {
            _context = context;
        }

        public void CreateBrand(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }

        public void CreateComment(WhatClientSays comment)
        {
            _context.WhatClientSays.Add(comment);
            _context.SaveChanges();
        }

        public void CreateMission(OurMission mission)
        {
            _context.ourMissions.Add(mission);
            _context.SaveChanges();
        }

        public void CreateTeamMember(TeamMember member)
        {
            _context.TeamMembers.Add(member);
            _context.SaveChanges();
        }

        public void DeleteBrand(Brand brand)
        {
            _context.Brands.Remove(brand);
            _context.SaveChanges();
        }

        public void DeleteComment(WhatClientSays comment)
        {
            _context.WhatClientSays.Remove(comment);
            _context.SaveChanges();
        }

        public void DeleteMission(OurMission mission)
        {
            _context.ourMissions.Remove(mission);
            _context.SaveChanges();
        }

        public void DeleteTeamMember(TeamMember member)
        {
            _context.TeamMembers.Remove(member);
            _context.SaveChanges();
        }

        public Brand GetBrandById(int id)
        {
            return _context.Brands.Find(id);
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.ToList();
        }

        public IEnumerable<OurMission> GetMission()
        {
            return _context.ourMissions.ToList();
        }

        public OurMission GetMissionById(int id)
        {
            return _context.ourMissions.Find(id);
        }

        public IEnumerable<TeamMember> GetTeamMember()
        {
            return _context.TeamMembers.ToList();
        }

        public TeamMember GetTeamMemberById(int id)
        {
            return _context.TeamMembers.Find(id);
        }

        public IEnumerable<WhatClientSays> GetWhatSays()
        {
            return _context.WhatClientSays.ToList();
        }

        public WhatClientSays GetWhatSaysById(int id)
        {
            return _context.WhatClientSays.Find(id);
        }

        public void UpdateBrand(Brand brand)
        {
            _context.Brands.Update(brand);
            _context.SaveChanges();
        }

        public void UpdateComment(WhatClientSays comment)
        {
            _context.WhatClientSays.Update(comment);
            _context.SaveChanges();
        }

        public void UpdateMission(OurMission mission)
        {
            _context.ourMissions.Update(mission);
            _context.SaveChanges();
        }

        public void UpdateTeamMember(TeamMember member)
        {
            _context.TeamMembers.Update(member);
            _context.SaveChanges();
        }
    }
}
