using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MayaFoods.Models
{
    public class MayaAdminDbContext : IdentityDbContext<AdminUser>
    {
       

        public MayaAdminDbContext()
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=3306;database=mayafoods;uid=root;pwd=root;");
        }

        public MayaAdminDbContext(DbContextOptions<MayaAdminDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
} 