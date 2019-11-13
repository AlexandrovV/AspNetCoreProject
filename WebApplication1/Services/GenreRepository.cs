using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DatabaseContext _dbContext;

        public GenreRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Genre genre)
        {
            _dbContext.Add(genre);
        }

        public void Delete(int id)
        {
            var genre = _dbContext.Genres.Find(id);
            _dbContext.Genres.Remove(genre);
        }

        public bool GenreExists(int id)
        {
            return _dbContext.Genres.Any(g => g.GenreId == id);
        }

        public Task<List<Genre>> GetAll()
        {
            return _dbContext.Genres.ToListAsync();
        }

        public Task<Genre> GetGenre(int id)
        {
            return _dbContext.Genres.FirstOrDefaultAsync(g => g.GenreId == id);
        }

        public Task Save()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Update(Genre genre)
        {
            _dbContext.Update(genre);
        }
    }
}
