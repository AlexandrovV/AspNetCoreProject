using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IDirectorRepository
    {
        void Add(Director director);
        void Update(Director director);
        Task Save();
        Task<List<Director>> GetAll();
        Task<Director> GetDirector(int id);
        void Delete(int id);
        bool DirectorExists(int id);
    }
}
