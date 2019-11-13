using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ReviewService
    {
        private readonly IReviewRepository _reviewRepo;

        public ReviewService(IReviewRepository reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        public async Task<List<Review>> GetReviews()
        {
            return await _reviewRepo.GetAll();
        }

        public async Task<Review> GetReview(int id)
        {
            return await _reviewRepo.GetReview(id);
        }

        public async Task AddAndSave(Review review)
        {
            _reviewRepo.Add(review);
            await _reviewRepo.Save();
        }

        public async Task UpdateAndSave(Review review)
        {
            _reviewRepo.Update(review);
            await _reviewRepo.Save();
        }

        public async Task DeleteAndSave(int id)
        {
            _reviewRepo.Delete(id);
            await _reviewRepo.Save();
        }

        public bool ReviewExists(int id)
        {
            return _reviewRepo.ReviewExists(id);
        }
    }
}
