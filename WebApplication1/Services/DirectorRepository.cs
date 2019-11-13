using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly DatabaseContext _dbContext;

        public DirectorRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Director director)
        {
            _dbContext.Add(director);
        }

        public void Update(Director director)
        {
            _dbContext.Update(director);
        }

        public void Delete(int id)
        {
            var director = _dbContext.Directors.Find(id);
            _dbContext.Directors.Remove(director);
        }

        public Task<List<Director>> GetAll()
        {
            return _dbContext.Directors.ToListAsync();
        }

        public Task<Director> GetDirector(int id)
        {
            return _dbContext.Directors.FirstOrDefaultAsync(d => d.DirectorId == id);
        }

        public Task Save()
        {
            return _dbContext.SaveChangesAsync();
        }

        public bool DirectorExists(int id)
        {
            return _dbContext.Directors.Any(e => e.DirectorId == id);
        }
    }
}
