using Microsoft.AspNetCore.Mvc;
using Mioca.Models;
using Repository.Repositories.ContentRepositories;
using Repository.Repositories.ShoppingRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Controllers
{
    public class AboutController : Controller
    {
        private readonly IContentRepository _content;
        private readonly IProductRepository _product;

        public AboutController(IContentRepository content, IProductRepository product)
        {
            _content = content;
            _product = product;
        }

        public IActionResult Index()
        {
        
            AboutViewModel model = new AboutViewModel
            {
                Missions = _content.GetMissions().FirstOrDefault(),
                TeamMembers=_content.GetTeamMembers().ToList(),
                whatClientSays=_content.GetWhatClientSays().ToList(),
                Brands=_content.GetBrands().ToList(),
               



        };
            return View(model);
        }

        public IActionResult Help()
        {
            return View();
        }
    }
}
