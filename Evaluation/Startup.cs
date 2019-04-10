using Evaluation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Evaluation
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

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //Require authenticated users
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                 .Build();
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            var connection = @"Server=(localdb)\mssqllocaldb;Database=EvaluationDB;Trusted_Connection=True;ConnectRetryCount=0;Connection Timeout=300";
            services.AddDbContext<Data.EvaluationDBContext>
                (options => options.UseSqlServer(connection));

            //Use ApplicationUser class
            services.AddIdentity<Models.ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<Data.EvaluationDBContext>()
               .AddDefaultUI()
               .AddDefaultTokenProviders();


            services.AddScoped<RoleManager<IdentityRole>>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();



            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{area:exists}/{controller=Identity/Account}/{action=Login}/{id?}");
            });

            Services.BasedOnRoles.CreateRole(serviceProvider, "Student");
            Services.BasedOnRoles.CreateRole(serviceProvider, "Profesor");
        }
    }
}
