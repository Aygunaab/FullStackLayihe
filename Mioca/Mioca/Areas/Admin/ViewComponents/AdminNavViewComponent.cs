using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mioca.Areas.Admin.Models;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.ViewComponents
{
    public class AdminNavViewComponent:ViewComponent
    {
        private readonly MiocaDbContext _context;
        private readonly UserManager<User> _usermanager;
        private readonly RoleManager<IdentityRole> _roleMangaer;
        private readonly SignInManager<User> _signinManager;

        public AdminNavViewComponent(MiocaDbContext context,
                                     UserManager<User> usermanager,
                                     RoleManager<IdentityRole> roleMangaer, 
                                     SignInManager<User> signinManager)
        {
            _context = context;
            _usermanager = usermanager;
            _roleMangaer = roleMangaer;
            _signinManager = signinManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string Id)
        {
            var user = await _usermanager.FindByIdAsync(Id);

         

           

            return View(user);
        }
    }
}
