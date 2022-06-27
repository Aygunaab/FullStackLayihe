using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mioca.Models;
using Repository.Models;
using Repository.Repositories.ContentRepositories;
using Repository.Repositories.ShoppingRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Controllers
{
    public class AboutController : BaseController
    {
        private readonly IContentRepository _content;
        private readonly IMapper _mapper;

        public AboutController(IContentRepository content, IMapper mapper)
        {
            _content = content;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var setting = _content.GetSetting();
            var teamMember = _content.GetTeamMembers();
            var teammodel = _mapper.Map<IEnumerable<TeamMember>, IEnumerable<TeamMemberViewModel>>(teamMember);
            AboutViewModel model = new AboutViewModel
            {
                Missions = _content.GetMissions(),
                TeamMembers=teammodel,
                whatClientSays=_content.GetWhatClientSays().ToList(),
                Brands=_content.GetBrands().ToList(),
                Setting = _content.Getset(),




            };
            return View(model);
        }

        public IActionResult Help()
        {
            return View();
        }
    }
}
