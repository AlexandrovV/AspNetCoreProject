using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DatabaseContext _dbContext;

        public ReviewRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Review review)
        {
            _dbContext.Add(review);
        }

        public void Delete(int id)
        {
            var review = _dbContext.Reviews.Find(id);
            _dbContext.Reviews.Remove(review);
        }

        public Task<List<Review>> GetAll()
        {
            return _dbContext.Reviews.Include(r => r.Movie).Include(r => r.Reviewer).ToListAsync();
        }

        public Task<Review> GetReview(int id)
        {
            return _dbContext.Reviews
                .Include(r => r.Movie)
                .Include(r => r.Reviewer)
                .FirstOrDefaultAsync(d => d.ReviewId == id);
        }

        public bool ReviewExists(int id)
        {
            return _dbContext.Reviews.Any(e => e.ReviewId == id);
        }

        public Task Save()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Update(Review review)
        {
            _dbContext.Update(review);
        }
    }
}
