using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace NamespaceGPT.Business.Services
{
    internal class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
        }

        public int AddReview(Review review)
        {
            return _reviewRepository.AddReview(review);
        }

        public bool DeleteReview(int id)
        {
            return _reviewRepository.DeleteReview(id);
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return _reviewRepository.GetAllReviews();
        }

        public Review? GetReview(int id)
        {
            return _reviewRepository.GetReview(id);
        }

        public IEnumerable<Review> GetReviewsForProduct(int productId)
        {
            return _reviewRepository.GetReviewsForProduct(productId);
        }

        public IEnumerable<Review> GetReviewsFromUser(int userId)
        {
            return _reviewRepository.GetReviewsFromUser(userId);
        }

        public bool UpdateReview(int id, Review review)
        {
            return _reviewRepository.UpdateReview(id, review);
        }
    }
}
