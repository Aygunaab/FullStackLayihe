using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mioca.Models;
using Repository.Data;
using Repository.Models;
using Repository.Repositories.ContentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.ViewComponents
{
    public class SliderViewComponent:ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IContentRepository _content;

        public SliderViewComponent(IMapper mapper, IContentRepository content)
        {

            _mapper = mapper;
            _content = content;
        }

        public IViewComponentResult Invoke()
        {
            var slider = _content.GetSliderItem();
            var model = _mapper.Map<IEnumerable<SliderItem>, IEnumerable<SliderViewModel>>(slider);

            return View(model);
        }
    }
}
