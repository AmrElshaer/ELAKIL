using ELAKIL.Business;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using ELAKIL.Business.Common.Models;
using ELAKIL.Business.IService;
using Rotativa.AspNetCore;

namespace ELAKIL.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Testing by Ahmed Mansour
        // Another New
        // One more

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBusiness(Configuration);
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddRazorPages();
            services.AddControllersWithViews().AddFluentValidation().AddRazorRuntimeCompilation();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
            });
            //Mail Configration
            var mailSetting = Configuration.GetSection(nameof(MailSettings));
            services.Configure<MailSettings>(a => {
                a.DisplayName = mailSetting[nameof(MailSettings.DisplayName)];
                a.Host = mailSetting[nameof(MailSettings.Host)];
                a.Password = mailSetting[nameof(MailSettings.Password)];
                a.Port = Convert.ToInt32(mailSetting[nameof(MailSettings.Port)]);
                a.Mail = mailSetting[nameof(MailSettings.Mail)];
            });
            //inject
            services.AddTransient<IMailService, MailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,Microsoft.AspNetCore.Hosting.IHostingEnvironment env2)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            // using this to make print
            RotativaConfiguration.Setup(env2);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
             name: "areas",
             pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
