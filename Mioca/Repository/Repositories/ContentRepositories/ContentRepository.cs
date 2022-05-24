using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.ContentRepositories
{
    public class ContentRepository : IContentRepository
    {
        private readonly MiocaDbContext _context;

        public ContentRepository(MiocaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Banner> GetBanners()
        {
            return _context.Banners.Where(b => b.Status)
                                  .ToList();
        }

        public IEnumerable<SliderItem> GetSliderItem()
        {
            return _context.Sliders.Where(s => s.Status)
                                   .OrderBy(s => s.OrderBy)
                                   .ToList();
        }
    }
}
