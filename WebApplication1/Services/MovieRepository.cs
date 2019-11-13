using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DatabaseContext _dbContext;

        public MovieRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Movie movie)
        {
            _dbContext.Add(movie);
        }

        public void Delete(int id)
        {
            var movie = _dbContext.Movies.Find(id);
            _dbContext.Movies.Remove(movie);
        }

        public Task<List<Movie>> GetAll()
        {
            return _dbContext
                .Movies
                .Include(m => m.Director)
                .Include(m => m.Studio)
                .ToListAsync();
        }

        public Task<Movie> GetMovie(int id)
        {
            return _dbContext
                .Movies
                .Include(m => m.Director)
                .Include(m => m.Studio)
                .FirstOrDefaultAsync(d => d.MovieId == id);
        }

        public bool MovieExists(int id)
        {
            return _dbContext.Movies.Any(e => e.MovieId == id);
        }

        public Task Save()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Update(Movie movie)
        {
            _dbContext.Update(movie);
        }
    }
}
