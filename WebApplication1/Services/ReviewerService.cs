using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ReviewerService
    {
        private readonly IReviewerRepository _reviewerRepo;

        public ReviewerService(IReviewerRepository reviewerRepo)
        {
            _reviewerRepo = reviewerRepo;
        }

        public async Task<List<Reviewer>> GetReviewers()
        {
            return await _reviewerRepo.GetAll();
        }

        public async Task<Reviewer> GetReviewer(int id)
        {
            return await _reviewerRepo.GetReviewer(id);
        }

        public async Task AddAndSave(Reviewer reviewer)
        {
            _reviewerRepo.Add(reviewer);
            await _reviewerRepo.Save();
        }

        public async Task UpdateAndSave(Reviewer reviewer)
        {
            _reviewerRepo.Update(reviewer);
            await _reviewerRepo.Save();
        }

        public async Task DeleteAndSave(int id)
        {
            _reviewerRepo.Delete(id);
            await _reviewerRepo.Save();
        }

        public bool ReviewerExists(int id)
        {
            return _reviewerRepo.ReviewerExists(id);
        }
    }
}
