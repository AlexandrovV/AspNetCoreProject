using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ActorRepository : IActorRepository
    {
        private readonly DatabaseContext _dbContext;

        public ActorRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Actor actor)
        {
            _dbContext.Add(actor);
        }

        public void Update(Actor actor)
        {
            _dbContext.Update(actor);
            
        }

        public Task<Actor> GetActor(int id)
        {
            return _dbContext.Actors.FirstOrDefaultAsync(m => m.ActorId == id);
        }

        public Task<List<Actor>> GetAll()
        {
            return _dbContext.Actors.ToListAsync();
        }

        public Task<List<Actor>> GetMovies(Expression<Func<Actor, bool>> predicate)
        {
            return _dbContext.Actors.Where(predicate).ToListAsync();
        }

        public Task Save()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var actor = _dbContext.Actors.Find(id);
            _dbContext.Actors.Remove(actor);
        }

        public bool ActorExists(int id)
        {
            return _dbContext.Actors.Any(e => e.ActorId == id);
        }
    }
}
