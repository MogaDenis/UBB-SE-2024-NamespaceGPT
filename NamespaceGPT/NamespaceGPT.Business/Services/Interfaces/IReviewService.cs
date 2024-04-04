using NamespaceGPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceGPT.Business.Services.Interfaces
{
    public interface IReviewService
    {
        int AddReview(Review review);
        bool DeleteReview(int id);
        bool UpdateReview(int id, Review review);
        IEnumerable<Review> GetAllReviews();
        Review? GetReview(int id);
        IEnumerable<Review> GetReviewsFromUser(int userId);
        IEnumerable<Review> GetReviewsForProduct(int productId);
    }
}
