using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.ContentRepositories
{
    public interface IContentRepository
    {
        IEnumerable<SliderItem> GetSliderItem();
        IEnumerable<SliderItem> GetSliderItemAdmin();
        IEnumerable<Banner> GetBanners();
        IEnumerable<Banner> GetBannersAdmin();
        IEnumerable<OurMission> GetMissions();
        IEnumerable<TeamMember> GetTeamMembers();
        IEnumerable<WhatClientSays> GetWhatClientSays();
        IEnumerable<Brand> GetBrands();     
        SliderItem GetSliderItemById(int id);
        //Slider Crud methods
        void CreateSlider(SliderItem slid);
        void DeleteSlider(SliderItem slider);
        void UpdateSlider(SliderItem slider);
        void CreateBanner(Banner banner);
        Banner GetBannerById(int id);
        void UpdateBanner(Banner banner);
        void DeleteBanner(Banner banner);
    }
    public class ContentRepository : IContentRepository
    {
        private readonly MiocaDbContext _context;

        public ContentRepository(MiocaDbContext context)
        {
            _context = context;
        }

        public void CreateBanner(Banner banner)
        {
            _context.Banners.Add(banner);
            _context.SaveChanges();
        }

        public void CreateSlider(SliderItem slid)
        {
           _context.Sliders.Add(slid);
           _context.SaveChanges();
        }

        public void DeleteBanner(Banner banner)
        {
            _context.Banners.Remove(banner);
            _context.SaveChanges();
        }

        public void DeleteSlider(SliderItem slider)
        {
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
        }

        public Banner GetBannerById(int id)
        {
            return _context.Banners.Find(id);
        }

        public IEnumerable<Banner> GetBanners()
        {
            return _context.Banners.Where(b => b.Status)
                                  .OrderByDescending(b => b.AddedDate)
                                   .Where(b => b.IsTopBanner)
                                  .Take(3)
                                  .ToList();
        }
        public IEnumerable<Banner> GetBannersAdmin()
        {
            return _context.Banners.OrderByDescending(b => b.AddedDate)
                                   .ToList();
        }



        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.Where(b => b.Status)
                                .ToList();
        }

        public IEnumerable<OurMission> GetMissions()
        {
            return _context.ourMissions.Where(b => b.Status)
                                .ToList();
        }

        public IEnumerable<SliderItem> GetSliderItem()
        {
            return _context.Sliders.Where(s => s.Status)
                                   .OrderBy(s => s.OrderBy)
                                   .ToList();
        }

        public IEnumerable<SliderItem> GetSliderItemAdmin()
        {
            return _context.Sliders.OrderBy(s => s.OrderBy)
                                    .ToList();
        }

        public SliderItem GetSliderItemById(int id)
        {
            return _context.Sliders.Find(id);
        }

        public IEnumerable<TeamMember> GetTeamMembers()
        {
            return _context.TeamMembers.Where(s => s.Status)
                                     .Include("Socials")
                                      .Include("Socials.Social")
                                     .ToList();
        }

        public IEnumerable<WhatClientSays> GetWhatClientSays()
        {
            return _context.WhatClientSays.Where(s => s.Status)
                                   .ToList();
        }

        public void UpdateBanner(Banner banner)
        {
            _context.Banners.Update(banner);
            _context.SaveChanges();
        }

        public void UpdateSlider(SliderItem slider)
        {
            _context.Sliders.Update(slider);
            _context.SaveChanges();
        }
    }
}
