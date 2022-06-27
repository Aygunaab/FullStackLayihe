using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mioca.Areas.Admin.Models.About;
using Repository.Constants;
using Repository.Extensions;
using Repository.Models;
using Repository.Repositories.AdminRepositories;
using Repository.Utils;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mioca.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutRepository _aboutcontent;
        private readonly IMapper _mapper;

        public AboutController(IAboutRepository aboutcontent, IMapper mapper)
        {
            _aboutcontent = aboutcontent;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var ourmission = _aboutcontent.GetMission();
            var missionmodel = _mapper.Map<IEnumerable<OurMission>, IEnumerable<OurMissionVm>>(ourmission);
            var teammember = _aboutcontent.GetTeamMember();
            var Membermodel = _mapper.Map<IEnumerable<TeamMember>, IEnumerable<TeamMemberVm>>(teammember);
            var Whatsays = _aboutcontent.GetWhatSays();
            var WhatsaysModel = _mapper.Map<IEnumerable<WhatClientSays>, IEnumerable<WhatClientSaysVm>>(Whatsays);
            var brands = _aboutcontent.GetBrands();
            var BrandModel = _mapper.Map<IEnumerable<Brand>, IEnumerable<BrandVm>>(brands);
            AboutVm model = new AboutVm
            {
                Missions = missionmodel,
                TeamMembers = Membermodel,
                whatClientSays = WhatsaysModel,
                Brands = BrandModel

            };
            return View(model);
        }

        #region OurMissionCrud
        public IActionResult Mission()
        {
            var ourmission = _aboutcontent.GetMission();
            var missionmodel = _mapper.Map<IEnumerable<OurMission>, IEnumerable<OurMissionVm>>(ourmission);
            return View(missionmodel);
        }
        public IActionResult DetailMission(int id)
        {
            var mission = _aboutcontent.GetMissionById(id);

            if (mission == null) return NotFound();

            return View(mission);
        }
        public IActionResult CreateMission()
        {

            OurMissionVm model = new OurMissionVm
            {
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateMission(OurMissionVm model)
        {

            if (!ModelState.IsValid) return View();

            if (!model.ImageFile.IsOkay())
            {
                ModelState.AddModelError(nameof(OurMissionVm.ImageFile), "File type is unsupported, please select image");
                return View(model);
            }

            OurMission mission = new OurMission
            {
                Status = model.Status,
                Title = model.Title,
                Desc = model.Desc,
                Videolink = model.Videolink,
                AddedDate = DateTime.Now,
                Image = FileUtils.Create(FileConstants.ImagePath, model.ImageFile)


            };


            _aboutcontent.CreateMission(mission);

            return RedirectToAction(nameof(Mission));
        }

        public IActionResult UpdateMission(int id)
        {
            var mission = _aboutcontent.GetMissionById(id);

            if (mission == null) return NotFound();
            OurMissionVm model = new OurMissionVm
            {
                Status = mission.Status,
                Title = mission.Title,
                Desc = mission.Desc,
                Videolink = mission.Videolink,
                Image=mission.Image

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateMission(int id, OurMissionVm model)
        {
            var mission = _aboutcontent.GetMissionById(id);

            if (mission == null) return NotFound();
            if (!ModelState.IsValid) return View(model);
            //main image
            if (model.ImageFile != null)
            {
                if (!model.ImageFile.IsOkay())
                {
                    ModelState.AddModelError(nameof(OurMissionVm.ImageFile), "There is a problem in your file");
                    return View(model);
                }
                FileUtils.Delete(Path.Combine(FileConstants.ImagePath, mission.Image));
            }

            mission.Status = model.Status;
            mission.Title = model.Title;
            mission.Desc = model.Desc;
            mission.Videolink = model.Videolink;

            mission.Image = model.ImageFile != null ? FileUtils.Create(FileConstants.ImagePath, model.ImageFile) : mission.Image;

            _aboutcontent.UpdateMission(mission);



            return RedirectToAction(nameof(Mission));


        }

        public IActionResult DeleteMission(int id)
        {
            var mission = _aboutcontent.GetMissionById(id);
            if (mission == null) return NotFound();

            FileUtils.Delete(mission.Image);

            _aboutcontent.DeleteMission(mission);


            return RedirectToAction(nameof(Mission));

        }
        #endregion

        #region WhatSaysCrud
        public IActionResult Comments()
        {
            var Whatsays = _aboutcontent.GetWhatSays();
            var WhatsaysModel = _mapper.Map<IEnumerable<WhatClientSays>, IEnumerable<WhatClientSaysVm>>(Whatsays);
            return View(WhatsaysModel);
        }
        public IActionResult DetailComment(int id)
        {
            var comment = _aboutcontent.GetWhatSaysById(id);

            if (comment == null) return NotFound();

            return View(comment);
        }
        public IActionResult CreateComment()
        {

            WhatClientSaysVm model = new WhatClientSaysVm
            {
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateComment(WhatClientSaysVm model)
        {

            if (!ModelState.IsValid) return View();

            if (!model.ClientImageFile.IsOkay())
            {
                ModelState.AddModelError(nameof(WhatClientSaysVm.ClientImageFile), "File type is unsupported, please select image");
                return View(model);
            }

            WhatClientSays comment = new WhatClientSays
            {
                Status = model.Status,
                ClientComment = model.ClientComment,
                FullName = model.FullName,
                companyName = model.companyName,
                AddedDate = DateTime.Now,
                ClientImage = FileUtils.Create(FileConstants.ImagePath, model.ClientImageFile)


            };


            _aboutcontent.CreateComment(comment);

            return RedirectToAction(nameof(Comments));
        }

        public IActionResult UpdateComment(int id)
        {
            var comment = _aboutcontent.GetWhatSaysById(id);

            if (comment == null) return NotFound();
            WhatClientSaysVm model = new WhatClientSaysVm
            {
                Status = comment.Status,
                ClientComment = comment.ClientComment,
                FullName = comment.FullName,
                companyName = comment.companyName,
                ClientImage=comment.ClientImage
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateComment(int id, WhatClientSaysVm model)
        {
            var comment = _aboutcontent.GetWhatSaysById(id);

            if (comment == null) return NotFound();
            if (!ModelState.IsValid) return View(model);
            //main image
            if (model.ClientImageFile != null)
            {
                if (!model.ClientImageFile.IsOkay())
                {
                    ModelState.AddModelError(nameof(WhatClientSaysVm.ClientImageFile), "There is a problem in your file");
                    return View(model);
                }
                FileUtils.Delete(Path.Combine(FileConstants.ImagePath, comment.ClientImage));
            }

            comment.Status = model.Status;
            comment.ClientComment = model.ClientComment;
            comment.FullName = comment.FullName;
            comment.companyName = comment.companyName;


            comment.ClientImage = model.ClientImageFile != null ? FileUtils.Create(FileConstants.ImagePath, model.ClientImageFile) : comment.ClientImage;

            _aboutcontent.UpdateComment(comment);



            return RedirectToAction(nameof(Comments));


        }

        public IActionResult DeleteComment(int id)
        {
            var comment = _aboutcontent.GetWhatSaysById(id);
            if (comment == null) return NotFound();

            FileUtils.Delete(comment.ClientImage);

            _aboutcontent.DeleteComment(comment);


            return RedirectToAction(nameof(Comments));

        }
        #endregion

        #region TeamMemberCrud
        public IActionResult Ourteam()
        {
            var teammember = _aboutcontent.GetTeamMember();
            var Membermodel = _mapper.Map<IEnumerable<TeamMember>, IEnumerable<TeamMemberVm>>(teammember);
            return View(Membermodel);
        }
        public IActionResult DetailTeamMember(int id)
        {
            var member = _aboutcontent.GetTeamMemberById(id);

            if (member == null) return NotFound();

            return View(member);
        }
        public IActionResult CreateTeamMember()
        {

            TeamMemberVm model = new TeamMemberVm
            {
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTeamMember(TeamMemberVm model)
        {

            if (!ModelState.IsValid) return View();

            if (!model.ImageFile.IsOkay())
            {
                ModelState.AddModelError(nameof(TeamMemberVm.ImageFile), "File type is unsupported, please select image");
                return View(model);
            }

            TeamMember member = new TeamMember
            {
                Status = model.Status,
                FullName = model.FullName,
                Profession = model.Profession,
                AddedDate = DateTime.Now,
                Image = FileUtils.Create(FileConstants.ImagePath, model.ImageFile)


            };


            _aboutcontent.CreateTeamMember(member);

            return RedirectToAction(nameof(Ourteam));
        }

        public IActionResult UpdateTeamMember(int id)
        {
            var member = _aboutcontent.GetTeamMemberById(id);

            if (member == null) return NotFound();
            TeamMemberVm teammember = new TeamMemberVm
            {
                Status = member.Status,
                FullName = member.FullName,
                Profession = member.Profession,
                Image=member.Image


            };
            return View(teammember);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateTeamMember(int id, TeamMemberVm model)
        {
            var member = _aboutcontent.GetTeamMemberById(id);

            if (member == null) return NotFound();
            if (!ModelState.IsValid) return View(model);
            //main image
            if (model.ImageFile != null)
            {
                if (!model.ImageFile.IsOkay())
                {
                    ModelState.AddModelError(nameof(TeamMemberVm.ImageFile), "There is a problem in your file");
                    return View(model);
                }
                FileUtils.Delete(Path.Combine(FileConstants.ImagePath, member.Image));
            }
            member.Status = model.Status;
            member.FullName = model.FullName;
            member.Profession = model.Profession;



            member.Image = model.ImageFile != null ? FileUtils.Create(FileConstants.ImagePath, model.ImageFile) : member.Image;

            _aboutcontent.UpdateTeamMember(member);



            return RedirectToAction(nameof(Ourteam));


        }

        public IActionResult DeleteTeamMember(int id)
        {
            var member = _aboutcontent.GetTeamMemberById(id);
            if (member == null) return NotFound();

            FileUtils.Delete(member.Image);

            _aboutcontent.DeleteTeamMember(member);


            return RedirectToAction(nameof(Ourteam));

        }
        #endregion
        #region BrandCrud
        public IActionResult Brand()
        {
            var brands = _aboutcontent.GetBrands();
            var BrandModel = _mapper.Map<IEnumerable<Brand>, IEnumerable<BrandVm>>(brands);
            return View(BrandModel);
        }
        public IActionResult DetailBrand(int id)
        {
            var brand = _aboutcontent.GetBrandById(id);

            if (brand == null) return NotFound();

            return View(brand);
        }
        public IActionResult CreateBrand()
        {

            BrandVm model = new BrandVm
            {
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBrand(BrandVm model)
        {

            if (!ModelState.IsValid) return View();

            if (!model.ImageFile.IsOkay())
            {
                ModelState.AddModelError(nameof(BrandVm.ImageFile), "File type is unsupported, please select image");
                return View(model);
            }

            Brand brend = new Brand
            {
                Status = model.Status,
                AddedDate = DateTime.Now,
                Icon = FileUtils.Create(FileConstants.ImagePath, model.ImageFile)


            };


            _aboutcontent.CreateBrand(brend);

            return RedirectToAction(nameof(Brand));
        }


        public IActionResult UpdateBrand(int id)
        {
            var brandmodel = _aboutcontent.GetBrandById(id);

            if (brandmodel == null) return NotFound();
            BrandVm brand = new BrandVm
            {
                Status = brandmodel.Status,
                Icon=brandmodel.Icon
            };
            return View(brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateBrand(int id, BrandVm model)
        {
            var brand = _aboutcontent.GetBrandById(id);

            if (brand == null) return NotFound();
            if (!ModelState.IsValid) return View(model);
            //main image
            if (model.ImageFile != null)
            {
                if (!model.ImageFile.IsOkay())
                {
                    ModelState.AddModelError(nameof(BrandVm.ImageFile), "There is a problem in your file");
                    return View(model);
                }
                FileUtils.Delete(Path.Combine(FileConstants.ImagePath, brand.Icon));
            }
            brand.Status = model.Status;




            brand.Icon = model.ImageFile != null ? FileUtils.Create(FileConstants.ImagePath, model.ImageFile) : brand.Icon;

            _aboutcontent.UpdateBrand(brand);



            return RedirectToAction(nameof(Brand));


        }

        public IActionResult DeleteBrand(int id)
        {
            var brand = _aboutcontent.GetBrandById(id);
            if (brand == null) return NotFound();

            FileUtils.Delete(brand.Icon);

            _aboutcontent.DeleteBrand(brand);


            return RedirectToAction(nameof(Brand));

        }
        #endregion
    }
}
