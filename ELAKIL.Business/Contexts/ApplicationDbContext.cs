using ELAKIL.Business.Common;
using ELAKIL.Business.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ELAKIL.Business.Contexts
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = ApplicationRoles.Admin.ToString(),
                NormalizedName = ApplicationRoles.Admin.ToString(),
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            var appUser = new IdentityUser()
            {
                Id = ADMIN_ID,
                Email = "Admin@elakil.com",
                EmailConfirmed = true,
                UserName = "Admin@elakil.com",
                NormalizedEmail = "ADMIN@ELAKIL.COM",
                NormalizedUserName = "ADMIN@ELAKIL.COM"
            };
            //set user password
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "P@ssword1");
            modelBuilder.Entity<IdentityUser>().HasData(appUser);
            //set user role to admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserCartItem> UserCartItems { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}