using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MayaFoods.Models
{
    public class EFProductRepository : IProductRepository
    {
        MayaFoodsContext db = new MayaFoodsContext();

        public EFProductRepository(MayaFoodsContext connection = null)
        {
            if (connection == null)
            {
                this.db = new MayaFoodsContext();
            }
            else
            {
                this.db = connection;
            }
        }

        public IQueryable<Product> Products
        { get { return db.Products; } }

        public Product Save(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product;
        }

        public Product Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return product;
        }

        public void Remove(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }
    }
}
