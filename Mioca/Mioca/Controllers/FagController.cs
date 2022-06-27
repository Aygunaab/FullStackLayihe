using Microsoft.AspNetCore.Mvc;
using Mioca.Areas.Admin.Models;
using Mioca.Models;
using Repository.Repositories.ContentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Controllers
{
    public class FagController : BaseController
    {
        private readonly IContentRepository _content;

        public FagController(IContentRepository content)
        {
            _content = content;
        }

        public IActionResult Index()
        {
           
            var fag = _content.GetFag();
            FagViewModel model = new FagViewModel
            {
                Fags=fag,
                Setting = _content.Getset(),
            };
           
            return View(model);
        }
    }
}
