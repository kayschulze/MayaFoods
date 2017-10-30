using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MayaFoods.Models
{
    public class EFReviewRepository : IReviewRepository
    {
        MayaAdminDbContext db = new MayaAdminDbContext();

        public IQueryable<Review> Reviews
        { get { return db.Reviews; } }

        public IQueryable<Product> Products
        { get { return db.Products; } }

        public Review Save(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return review;
        }

        public Review Edit(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
            return review;
        }

        public void Remove(Review review)
        {
            db.Reviews.Remove(review);
            db.SaveChanges();
        }
    }
}