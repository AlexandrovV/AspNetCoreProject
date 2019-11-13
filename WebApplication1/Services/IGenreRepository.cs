using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IGenreRepository
    {
        void Add(Genre genre);
        void Update(Genre genre);
        Task Save();
        Task<List<Genre>> GetAll();
        Task<Genre> GetGenre(int id);
        void Delete(int id);
        bool GenreExists(int id);
    }
}
