using ELAKIL.Business.Contexts;
using ELAKIL.Business.IService;
using ELAKIL.Business.Service;
using ELAKIL.Business.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace ELAKIL.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(
                 configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>()
                  .AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>();
            // Config Fluent Validation
            AssemblyScanner.FindValidatorsInAssembly(typeof(CategoryValidator).Assembly)
             .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            services.Configure<IdentityOptions>(opts => {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 8;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
            });

            //Inject Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserProfileService, UserProfileService>();
            return services;
        }
    }
}
