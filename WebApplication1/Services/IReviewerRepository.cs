using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IReviewerRepository
    {
        void Add(Reviewer reviewer);
        void Update(Reviewer reviewer);
        Task Save();
        Task<List<Reviewer>> GetAll();
        Task<Reviewer> GetReviewer(int id);
        void Delete(int id);
        bool ReviewerExists(int id);
    }
}
