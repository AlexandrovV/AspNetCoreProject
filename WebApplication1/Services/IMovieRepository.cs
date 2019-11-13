using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IMovieRepository
    {
        void Add(Movie movie);
        void Update(Movie movie);
        Task Save();
        Task<List<Movie>> GetAll();
        Task<Movie> GetMovie(int id);
        void Delete(int id);
        bool MovieExists(int id);
    }
}
