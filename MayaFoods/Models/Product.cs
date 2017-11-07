using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MayaFoods.Models
{
    [Table("Products")]

    public class Product
    {
        MayaAdminDbContext db = new MayaAdminDbContext();

        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Origincountry { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public Product() { }

        public Product(int productid, string name, double cost, string origincountry)
        {
            ProductId = productid;
            Name = name;
            Cost = cost;
            Origincountry = origincountry;
        }

        public double AverageRating()
        {
            double ratingAverage = 0;
            double numberOfReviews = this.Reviews.Count();
            double totalReviewScore = 0;

            foreach (var review in Reviews)
            {
                totalReviewScore += review.Rating;
            }

            ratingAverage = totalReviewScore / numberOfReviews;

            return ratingAverage;
        }

        public IEnumerable<Product> GetLastThree()
        {
            IEnumerable<Product> lastthree;
            lastthree = db.Products
                          .Include(p => p.Reviews)
                          .OrderByDescending(p => p.ProductId)
                          .Take(3)
                          .ToList();

            return lastthree; 
        }

        public IEnumerable<Product> GetBestThree()
        {
            IEnumerable<Product> bestthree;
            bestthree = db.Products
                          .Include(p => p.Reviews)
                          .OrderByDescending(p => p.ProductId)
                          .Take(3)
                          .ToList();

            return bestthree;
        }


        public override bool Equals(System.Object otherProduct)
        {
            if (!(otherProduct is Product))
            {
                return false;
            }
            else
            {
                Product newProduct = (Product)otherProduct;
                bool idEquality = this.ProductId == newProduct.ProductId;
                bool nameEquality = this.Name == newProduct.Name;
                bool costEquality = this.Cost == newProduct.Cost;
                bool origincountryEquality = this.Origincountry == newProduct.Origincountry;

                return (idEquality && nameEquality && costEquality && origincountryEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.ProductId.GetHashCode();
        }
    }
}
