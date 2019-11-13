using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ActorService
    {
        private readonly IActorRepository _actorRepo;

        public ActorService(IActorRepository actorRepo)
        {
            _actorRepo = actorRepo;
        }

        public async Task<List<Actor>> GetActors()
        {
            return await _actorRepo.GetAll();
        }

        public async Task<Actor> GetActor(int id)
        {
            return await _actorRepo.GetActor(id);
        }

        public async Task AddAndSave(Actor actor)
        {
            _actorRepo.Add(actor);
            await _actorRepo.Save();
        }

        public async Task UpdateAndSave(Actor actor)
        {
            _actorRepo.Update(actor);
            await _actorRepo.Save();
        }

        public async Task DeleteAndSave(int id)
        {
            _actorRepo.Delete(id);
            await _actorRepo.Save();
        }

        public bool ActorExists(int id)
        {
            return _actorRepo.ActorExists(id);
        }
        

        public bool CheckActorName(string name)
        {
            if (name == "Vladislav Alexandrov")
            {
                return false;
            }
            return true;
        }
    }
}
