using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Data;
using Repository.Repositories.ShoppingRepositories;
using Repository.Repositories.ContentRepositories;
using Repository.Models;
using Microsoft.AspNetCore.Identity;
using Mioca.Settings;
using Mioca.Services;
using Mioca.Libs;
using System;
using Repository.Constants;
using System.IO;
using Repository.Repositories.AdminRepositories;

namespace Mioca
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddMvc(
                config =>
                {
                    config.Filters.Add(new GlobalToken());

                });
            services.AddDbContext<MiocaDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Default"),
                x => x.MigrationsAssembly("Repository")));
            FileConstants.ImagePath = Path.Combine(_env.WebRootPath, "Uploads");

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;

            }).AddEntityFrameworkStores<MiocaDbContext>().AddDefaultTokenProviders();

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, Mioca.Services.MailService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IContentRepository, ContentRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            //admin panel repositories
            services.AddTransient<IAboutRepository, AboutRepository>();
            services.AddTransient<IAdminContentRepository, AdminContentRepository>();
            services.AddTransient<IProductAdminRepository, ProductAdminRepository>();
            services.AddTransient<IBlogRepository, BlogRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
