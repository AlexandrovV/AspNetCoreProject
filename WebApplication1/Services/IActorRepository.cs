using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IActorRepository
    {
        void Add(Actor actor);
        void Update(Actor actor);
        Task Save();
        Task<List<Actor>> GetAll();
        Task<Actor> GetActor(int id);
        void Delete(int id);
        bool ActorExists(int id);
        Task<List<Actor>> GetMovies(Expression<Func<Actor, bool>> predicate);
    }
}
