using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories.ContentRepositories
{
    public interface IContentRepository
    {
        IEnumerable<SliderItem> GetSliderItem();
        IEnumerable<SliderItem> GetSliderItemAdmin();
        IEnumerable<Banner> GetBanners();
        IEnumerable<Banner> GetBannersAdmin();
        IEnumerable<OurMission> GetMissions();
        IEnumerable<Fag>GetFag();
        IEnumerable<TeamMember> GetTeamMembers();
        IEnumerable<WhatClientSays> GetWhatClientSays();
        IEnumerable<Brand> GetBrands();     
        SliderItem GetSliderItemById(int id);
       IEnumerable<Blog> GetBlog();

        //Slider Crud methods
        void CreateSlider(SliderItem slid);
        void DeleteSlider(SliderItem slider);
        void UpdateSlider(SliderItem slider);
        void CreateBanner(Banner banner);
        Banner GetBannerById(int id);
        void UpdateBanner(Banner banner);
        void DeleteBanner(Banner banner);
        IEnumerable<Setting> GetSetting();
        IEnumerable<Contact>GetContact();
        void CreateMessage(ContactMessage message);
        Setting Getset();
        bool Subscribe(string email);
        void AddSubscribe(Subscribe subscribe);
        void CreateCommentProduct(ProductReview comment);
        Country GetUserCountry(int? countryId);
        IEnumerable<Tax> GetTax();
        List<Country> getContrys();
       Blog GetBlogId(int id);
        void CreateCommentBlog(BlogComment comment);
    
    }
    public class ContentRepository : IContentRepository
    {
        private readonly MiocaDbContext _context;

        public ContentRepository(MiocaDbContext context)
        {
            _context = context;
        }

        public void AddSubscribe(Subscribe subscribe)
        {
            _context.Subscribes.Add(subscribe);
            _context.SaveChanges();
        }

        public void CreateBanner(Banner banner)
        {
            _context.Banners.Add(banner);
            _context.SaveChanges();
        }

        public void CreateCommentBlog(BlogComment comment)
        {
            _context.BlogComments.Add(comment);
            _context.SaveChanges();
        }

        public void CreateCommentProduct(ProductReview comment)
        {
             _context.ProductReviews.Add(comment);
             _context.SaveChanges();
        }

        public void CreateMessage(ContactMessage message)
        {
            _context.contactMessages.Add(message);
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

        public IEnumerable<Blog> GetBlog()
        {
            return _context.Blogs
                .Include("Category")
                .Include("TagToBlogs")
                .Include("TagToBlogs.Tag")
                .Include("User")
                .Where(b => b.Status)
                .OrderByDescending(b => b.AddedDate)
                .Take(3)
                .ToList();
        }

     

        public Blog GetBlogId(int id)
        {
            return _context.Blogs.Include("Category")
                                     .Include("Comments")
                                     .Include("Comments.User")
                                     .Include("TagToBlogs")
                                     .Include("TagToBlogs.Tag")
                                     .Include("User")
                                     .FirstOrDefault(p => p.Status && p.Id == id);
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.Where(b => b.Status)
                                .ToList();
        }

        public IEnumerable<Contact> GetContact()
        {
            return _context.Contacts.Include(c => c.Socials).ToList();
        }

        public List<Country> getContrys()
        {
            return _context.Countries.ToList();
        }

        public IEnumerable<Fag> GetFag()
        {
            return _context.Fags.Where(b => b.Status)
                                .OrderByDescending(m => m.AddedDate)
                                .Take(30)
                                .ToList();
        }

        public IEnumerable<OurMission> GetMissions()
        {
            return _context.ourMissions.Where(b => b.Status)
                                .OrderByDescending(m=>m.AddedDate)
                                .Take(1)
                                .ToList();
        }

        public Setting Getset()
        {
            return _context.Settings.FirstOrDefault();
        }

        public IEnumerable<Setting> GetSetting()
        {
            return _context.Settings.Where(s => s.Status)
                                    .OrderByDescending(s=>s.AddedDate)
                                    .Take(1)
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

        public IEnumerable<Tax> GetTax()
        {
            return _context.Taxs.ToList();
        }

        public IEnumerable<TeamMember> GetTeamMembers()
        {
            return _context.TeamMembers.Where(s => s.Status)
                                     .Include("Socials")
                                      .Include("Socials.Social")
                                     .ToList();
        }

        public Country GetUserCountry(int? countryId)
        {
           return _context.Countries.Find(countryId);
        }

        public IEnumerable<WhatClientSays> GetWhatClientSays()
        {
            return _context.WhatClientSays.Where(s => s.Status)
                                   .ToList();
        }

        public bool Subscribe(string email)
        {
           return _context.Subscribes.Any(e => e.Email == email);
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
