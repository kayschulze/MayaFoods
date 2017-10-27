using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MayaFoods.Models
{
    public class EFReviewRepository : IReviewRepository
    {
        MayaFoodsContext db = new MayaFoodsContext();

        public IQueryable<Review> Reviews
        { get { return db.Reviews; } }

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