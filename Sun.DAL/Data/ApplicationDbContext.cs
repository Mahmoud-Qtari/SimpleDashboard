using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sun.DAL.Models;

namespace Sun.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<About> abouts { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Professional> professionals{ get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Package> packages { get; set; }
        public DbSet<PackageItem> packageitems { get; set; }
    }
}
