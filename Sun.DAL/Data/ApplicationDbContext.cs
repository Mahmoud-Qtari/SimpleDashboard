using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sun.DAL.Models;

namespace Sun.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var userIDRole = Guid.NewGuid().ToString();
            var AdminIDRole = Guid.NewGuid().ToString();
            var SuperadminIDRole = Guid.NewGuid().ToString();
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id= userIDRole,Name="User",NormalizedName="USER"},
                new IdentityRole { Id = AdminIDRole, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = SuperadminIDRole, Name = "SuperAdmin", NormalizedName = "SUPERADMIN" }
            );

            var hasher = new PasswordHasher<ApplicationUser>();
            var adminUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser,"Admin@1212");
            var SuperAdminUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "superadmin@superadmin.com",
                NormalizedUserName = "SUPERADMIN@SUPERADMIN.COM",
                Email = "superadmin@superadmin.com",
                NormalizedEmail = "SUPERADMIN@SUPERADMIN.COM",
                EmailConfirmed = true
            };
            SuperAdminUser.PasswordHash = hasher.HashPassword(SuperAdminUser, "Super@1212");
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user@user.com",
                NormalizedUserName = "USER@USER.COM",
                Email = "user@user.com",
                NormalizedEmail = "USER@USER.COM",
                EmailConfirmed = true
            };
            user.PasswordHash = hasher.HashPassword(user, "User@1212");

            builder.Entity<ApplicationUser>().HasData(user, adminUser, SuperAdminUser);
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = userIDRole, UserId = user.Id },
                new IdentityUserRole<string> { RoleId = AdminIDRole, UserId = adminUser.Id },
                new IdentityUserRole<string> { RoleId = SuperadminIDRole, UserId = SuperAdminUser.Id }
            );
        }
        public DbSet<About> abouts { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Professional> professionals{ get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Package> packages { get; set; }
        public DbSet<PackageItem> packageitems { get; set; }
    }
}
