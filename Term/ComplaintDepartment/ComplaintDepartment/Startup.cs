using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ComplaintDepartment.Models.Repositories;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using ComplaintDepartment.Models;


namespace ComplaintDepartment
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            /* Repositories */
            services.AddTransient<IComplaintRepository, ComplaintRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();

            /* Users */
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:Local"]));
            services.AddIdentity<AppUser, IdentityRole>(opts => {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDBContext>()
        .AddDefaultTokenProviders();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            // https://github.com/aspnet/Identity/issues/1065
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var signInManager = serviceScope.ServiceProvider.GetService<SignInManager<AppUser>>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<AppUser>>();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
           AppDBContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
            app.UseMvc(routes =>
            {
                //Custom route for getting single complaint
                routes.MapRoute(
                   "GetComplaint",
                   "Complaint/Get/{id}",
                   new { controller = "Complaint", action = "GetComplaint" }
                );
                   
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
