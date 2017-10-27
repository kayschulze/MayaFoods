using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MayaFoods.Models
{
    [Table("Reviews")]

    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string Author { get; set; }
        public string ContentBody { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Review() { }

        public Review(int reviewid, string author, string contentbody, int rating, int productid)
        {
            ReviewId = reviewid;
            Author = author;
            ContentBody = contentbody;
            Rating = rating;
            ProductId = productid;
        }

        public override bool Equals(System.Object otherReview)
        {
            if (!(otherReview is Review))
            {
                return false;
            }
            else
            {
                Review newReview = (Review)otherReview;
                bool idEquality = this.ReviewId == newReview.ReviewId;
                bool authorEquality = this.Author == newReview.Author;
                bool contentBodyEquality = this.ContentBody == newReview.ContentBody;
                bool ratingEquality = this.Rating == newReview.Rating;
                bool productIdEquality = this.ProductId == newReview.ProductId;

                return (idEquality && authorEquality && contentBodyEquality && ratingEquality && productIdEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.ReviewId.GetHashCode();
        }
    }
}