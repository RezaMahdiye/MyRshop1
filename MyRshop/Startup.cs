using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyRshop.Data;
using MyRshop.Data.Repositories;

namespace MyRshop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration; 
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
  

            services.AddRazorPages();

            #region Db Context
            services.AddDbContext<MyRshopContext>(options =>
options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));



            //services.AddDbContext<MyRshopContext>(options => { options.UseSqlServer("Data Source=.;Initial Catalog=RshopCore_DB;Integrated Security=true") ; });

            #endregion

            #region IoC
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region Authentication

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/Account/Login";
                    option.LogoutPath = "/Account/Logout";
                    option.ExpireTimeSpan = TimeSpan.FromDays(10);
                });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            UpdateDatabase(app);
            app.UseDeveloperExceptionPage();

            //if (env.IsDevelopment())
            //{
            //    //app.UseDeveloperExceptionPage();

            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //}
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.Use(async (context, next) => {
                if (context.Request.Path.StartsWithSegments("/Admin"))
                {
                    if (!context.User.Identity.IsAuthenticated)
                    {
                        context.Response.Redirect("/Account/Login");

                    }
                    else if(!bool.Parse(context.User.FindFirstValue("IsAdmin"))){

                        context.Response.Redirect("/Account/Login");
                    }
                }
                await next.Invoke();
            });

            app.UseEndpoints(endpoints =>
            {
               endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<MyRshopContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}