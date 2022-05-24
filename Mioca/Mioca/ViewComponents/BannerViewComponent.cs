using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mioca.Models;
using Repository.Models;
using Repository.Repositories.ContentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.ViewComponents
{
    public class BannerViewComponent:ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IContentRepository _content;

        public BannerViewComponent(IMapper mapper, IContentRepository content)
        {
            _mapper = mapper;
            _content = content;
        }

        public IViewComponentResult Invoke()
        {
            var banner = _content.GetBanners();
            var model = _mapper.Map<IEnumerable<Banner>, IEnumerable<BannerViewModel>>(banner);

            return View(model);
        }
    }
}
