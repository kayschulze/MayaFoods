using System.Linq;

namespace MayaFoods.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        IQueryable<Product> GetLastProducts { get; }
        Product Save(Product product);
        Product Edit(Product product);
        void Remove(Product product);
    }
}
