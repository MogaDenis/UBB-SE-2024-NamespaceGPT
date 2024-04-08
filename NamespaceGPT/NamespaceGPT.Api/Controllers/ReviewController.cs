using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;

namespace NamespaceGPT.Api.Controllers
{
    public class ReviewController
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
        }

        public int AddReview(Review review)
        {
            return _reviewService.AddReview(review);
        }

        public bool DeleteReview(int id)
        {
            return _reviewService.DeleteReview(id);
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return _reviewService.GetAllReviews();
        }

        public Review? GetReview(int id)
        {
            return _reviewService.GetReview(id);
        }

        public IEnumerable<Review> GetReviewsForProduct(int productId)
        {
            return _reviewService.GetReviewsForProduct(productId);
        }

        public IEnumerable<Review> GetReviewsFromUser(int userId)
        {
            return _reviewService.GetReviewsFromUser(userId);
        }

        public bool UpdateReview(int id, Review review)
        {
            return _reviewService.UpdateReview(id, review);
        }
    }
}
