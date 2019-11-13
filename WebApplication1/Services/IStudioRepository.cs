using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IStudioRepository
    {
        void Add(Studio studio);
        void Update(Studio studio);
        Task Save();
        Task<List<Studio>> GetAll();
        Task<Studio> GetStudio(int id);
        void Delete(int id);
        bool StudioExists(int id);
    }
}
