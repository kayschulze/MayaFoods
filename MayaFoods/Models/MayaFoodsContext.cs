using Microsoft.EntityFrameworkCore;

namespace MayaFoods.Models
{
    public class MayaFoodsContext : DbContext
    {
        public MayaFoodsContext()
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=3306;database=mayaspecialtyfoodsmigrations;uid=root;pwd=root;");
        }

        public MayaFoodsContext(DbContextOptions<MayaFoodsContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}