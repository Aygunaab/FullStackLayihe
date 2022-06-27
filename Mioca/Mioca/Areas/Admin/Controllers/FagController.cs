using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mioca.Areas.Admin.Models;
using Repository.Models;
using Repository.Repositories.AdminRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class FagController:Controller
    {
        private readonly IAdminContentRepository _content;
        private readonly IMapper _mapper;

        public FagController(IAdminContentRepository content, IMapper mapper)
        {
            _content = content;
            _mapper = mapper;
        }
        public IActionResult Fag()
        {
            var fag = _content.GetFag();
            var model = _mapper.Map<IEnumerable<Fag>, IEnumerable<FagVm>>(fag);
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var help = _content.GetFagById(id);

            if (help == null) return NotFound();

            return View(help);
        }

        public IActionResult Create()
        {

            FagVm model = new FagVm
            {
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FagVm model)
        {

            if (!ModelState.IsValid) return View();



            Fag help = new Fag
            {
                Status = model.Status,
              Question=model.Question,
              Answer=model.Answer,
                AddedDate = DateTime.Now,
            };


            _content.CreateFag(help);

            return RedirectToAction(nameof(Fag));
        }

        public IActionResult Update(int id)
        {
            var help = _content.GetFagById(id);

            if (help == null) return NotFound();
            FagVm model = new FagVm
            {
                Status = help.Status,
               Question=help.Question,
                ModifiedDate = DateTime.Now,


            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, FagVm model)
        {
            var help = _content.GetFagById(id);

            if (help == null) return NotFound();
            if (!ModelState.IsValid) return View(model);
            
            help.Status = model.Status;
            help.Question = model.Question;
            help.ModifiedDate = DateTime.Now;
   
            _content.UpdateMission(help);

            return RedirectToAction(nameof(Fag));


        }
        public IActionResult Delete(int id)
        {
            var help = _content.GetFagById(id);
            if (help == null) return NotFound();

          

            _content.DeleteFag(help);


            return RedirectToAction(nameof(Fag));

        }
    }
}
