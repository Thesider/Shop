using ASP.NET.Models;

namespace ASP.NET.Data.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviews();
        Task<Review> GetReview(int id);
        Task<Review> AddReview(Review review);
        Task<Review> UpdateReview(Review review);
        Task<Review> DeleteReview(int id);
    }
}