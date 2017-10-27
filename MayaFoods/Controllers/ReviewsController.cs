using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MayaFoods.Models;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            reviewRepo.Save(review);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
    }
}
