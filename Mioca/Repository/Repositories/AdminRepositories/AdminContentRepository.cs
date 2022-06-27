using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.AdminRepositories
{
    public interface IAdminContentRepository
    {
        IEnumerable<Fag>GetFag();
        Fag GetFagById(int id);
        void CreateFag(Fag help);
        void UpdateMission(Fag help);
        void DeleteFag(Fag help);
       IEnumerable<Setting> GetLayout();
        void CreateSetting(Setting setting);
        Setting GetSettingById(int id);
        void UpdateLayout(Setting setting);
        void DeleteLayout(Setting layout);
    }
    public class AdminContentRepository:IAdminContentRepository
    {
        private readonly MiocaDbContext _context;

        public AdminContentRepository(MiocaDbContext context)
        {
            _context = context;
        }

        public void CreateFag(Fag help)
        {
            _context.Fags.Add(help);
            _context.SaveChanges();
        }

        public void CreateSetting(Setting setting)
        {
            _context.Settings.Add(setting);
            _context.SaveChanges();
        }

        public void DeleteFag(Fag help)
        {
            _context.Fags.Remove(help);
            _context.SaveChanges();
        }

        public void DeleteLayout(Setting layout)
        {
            _context.Settings.Remove(layout);
            _context.SaveChanges();
        }

        public IEnumerable<Fag> GetFag()
        {
            return _context.Fags
                              .OrderByDescending(p => p.AddedDate)
                               .ToList();
        }

        public Fag GetFagById(int id)
        {
            return _context.Fags.Find(id);
        }

        public IEnumerable<Setting> GetLayout()
        {
            return _context.Settings.ToList();
        }

        public Setting GetSettingById(int id)
        {
            return _context.Settings.Find(id);
        }

        public void UpdateLayout(Setting setting)
        {
            _context.Settings.Update(setting);
            _context.SaveChanges();
        }

        public void UpdateMission(Fag help)
        {
            _context.Fags.Update(help);
            _context.SaveChanges();
        }
    }
}
