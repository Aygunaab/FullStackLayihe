using Microsoft.AspNetCore.Identity;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Data
{
    public class DataInitialiaser
    {
        private readonly MiocaDbContext _context;
        private RoleManager<IdentityRole> _roleManager;

        public DataInitialiaser(MiocaDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        public async  Task SeedData()
        {
            if (!_context.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Moderator"));
                await _roleManager.CreateAsync(new IdentityRole("Teacher"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }
        }
    }
}
