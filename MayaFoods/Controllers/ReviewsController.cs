using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MayaFoods.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MayaFoods.Controllers
{
    public class ReviewsController : Controller
    {
        private IReviewRepository reviewRepo;

        public ReviewsController(IReviewRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.reviewRepo = new EFReviewRepository();
            }
            else
            {
                this.reviewRepo = thisRepo;
            }
        }

        public IActionResult Index()
        {
            return View(reviewRepo.Reviews.Include(reviews => reviews.Product).ToList());
        }

        public IActionResult Details(int id)
        {
            var thisReview = reviewRepo.Reviews.FirstOrDefault(x => x.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost]
        public IActionResult ProductView(string ReviewAuthor, string ReviewContentBody, int ReviewRating, int ReviewProductId)
        {
            Review MyNewReview = new Review(ReviewAuthor, ReviewContentBody, ReviewRating, ReviewProductId);
            reviewRepo.Save(MyNewReview);
            return Json(MyNewReview);
        }

        //public IActionResult CreateReview()
        //{
        //    ViewBag.thisProduct = reviewRepo.Products;
        //    return View();
        //}

        public IActionResult CreateReview()
        {
            ViewBag.thisProduct = reviewRepo.Products;
            return View();
        }

        [HttpPost]
        public IActionResult CreateReview(Review review)
        {
            reviewRepo.Save(review);
            return RedirectToAction("Details", "Products", new { id = review.ProductId });
        }

        public IActionResult Edit(int id)
        {
            var thisReview = reviewRepo.Reviews.FirstOrDefault(x => x.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost]
        public IActionResult Edit(Review review)
        {
            reviewRepo.Edit(review);
            //return RedirectToAction("Details", "Products", new { id = review.ProductId }); 
            //return RedirectToAction("Index", "Products");
            return Json(review);
        }

        public ActionResult Delete(int id)
        {
            var thisReview = reviewRepo.Reviews.FirstOrDefault(x => x.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(x => x.ReviewId == id);
            reviewRepo.Remove(thisReview);
            return View(thisReview);
        }
    }
}
