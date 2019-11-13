using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IReviewRepository
    {
        void Add(Review review);
        void Update(Review review);
        Task Save();
        Task<List<Review>> GetAll();
        Task<Review> GetReview(int id);
        void Delete(int id);
        bool ReviewExists(int id);
    }
}
