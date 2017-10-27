using Microsoft.EntityFrameworkCore;

namespace MayaFoods.Models
{
    public class TestDbContext : MayaFoodsContext
    {
        public override DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;database=mayaspecialtyfoods_test;uid=root;pwd=root;");
        }
    }
}