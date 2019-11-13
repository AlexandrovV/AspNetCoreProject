using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class StudioRepository : IStudioRepository
    {
        private readonly DatabaseContext _dbContext;

        public StudioRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Studio studio)
        {
            _dbContext.Add(studio);
        }

        public void Delete(int id)
        {
            var studio = _dbContext.Studios.Find(id);
            _dbContext.Studios.Remove(studio);
        }

        public Task<List<Studio>> GetAll()
        {
            return _dbContext.Studios.ToListAsync();
        }

        public Task<Studio> GetStudio(int id)
        {
            return _dbContext.Studios.FirstOrDefaultAsync(s => s.StudioId == id);
        }

        public Task Save()
        {
            return _dbContext.SaveChangesAsync();
        }

        public bool StudioExists(int id)
        {
            return _dbContext.Studios.Any(s => s.StudioId == id);
        }

        public void Update(Studio studio)
        {
            _dbContext.Update(studio);
        }
    }
}
