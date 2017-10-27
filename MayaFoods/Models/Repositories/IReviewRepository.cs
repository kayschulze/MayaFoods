﻿using System.Linq;

namespace MayaFoods.Models
{
    public interface IReviewRepository
    {
        IQueryable<Review> Reviews { get; }
        Review Save(Review review);
        Review Edit(Review review);
        void Remove(Review review);
    }
}
