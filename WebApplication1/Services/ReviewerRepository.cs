using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DatabaseContext _dbContext;

        public ReviewerRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Reviewer reviewer)
        {
            _dbContext.Add(reviewer);
        }

        public void Delete(int id)
        {
            var reviewer = _dbContext.Reviewers.Find(id);
            _dbContext.Reviewers.Remove(reviewer);
        }

        public Task<List<Reviewer>> GetAll()
        {
            return _dbContext.Reviewers.ToListAsync();
        }

        public Task<Reviewer> GetReviewer(int id)
        {
            return _dbContext.Reviewers.FirstOrDefaultAsync(r => r.ReviewerId == id);
        }

        public bool ReviewerExists(int id)
        {
            return _dbContext.Reviewers.Any(r => r.ReviewerId == id);
        }

        public Task Save()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Update(Reviewer reviewer)
        {
            _dbContext.Update(reviewer);
        }
    }
}
