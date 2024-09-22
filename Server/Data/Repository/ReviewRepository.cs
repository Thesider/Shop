using ASP.NET.Data.Interfaces;
using ASP.NET.Models;

namespace ASP.NET.Data.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private List<Review> _reviews;

        public ReviewRepository()
        {
            _reviews = new List<Review>();
        }

        public async Task<IEnumerable<Review>> GetReviews()
        {
            return await Task.FromResult(_reviews);
        }

        public async Task<Review> GetReview(int id)
        {
            return await Task.FromResult(_reviews.FirstOrDefault(r => r.ReviewId == id));
        }

        public async Task<Review> AddReview(Review review)
        {
            if (_reviews.Count > 0)
            {
                review.ReviewId = _reviews.Max(r => r.ReviewId) + 1;
            }
            else
            {
                review.ReviewId = 1;
            }
            _reviews.Add(review);
            return await Task.FromResult(review);
        }

        public async Task<Review> UpdateReview(Review review)
        {
            var existingReview = _reviews.FirstOrDefault(r => r.ReviewId == review.ReviewId);
            if (existingReview != null)
            {
                existingReview.ReviewContent = review.ReviewContent;
                existingReview.Rating = review.Rating;
            }
            return await Task.FromResult(existingReview);
        }

        public async Task<Review> DeleteReview(int id)
        {
            var review = _reviews.FirstOrDefault(r => r.ReviewId == id);
            if (review != null)
            {
                _reviews.Remove(review);
            }
            return await Task.FromResult(review);
        }
    }
}