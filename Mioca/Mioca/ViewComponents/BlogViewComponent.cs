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
    public class BlogViewComponent:ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IContentRepository _content;

        public BlogViewComponent(IMapper mapper, IContentRepository content)
        {
            _mapper = mapper;
            _content = content;
        }

        public IViewComponentResult Invoke()
        {
            var blog= _content.GetBlog();
            return View(blog);
        }
    }
}
