using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class StudioService
    {
        private readonly IStudioRepository _studioRepo;

        public StudioService(IStudioRepository studioRepo)
        {
            _studioRepo = studioRepo;
        }

        public async Task<List<Studio>> GetStudios()
        {
            return await _studioRepo.GetAll();
        }

        public async Task<Studio> GetStudio(int id)
        {
            return await _studioRepo.GetStudio(id);
        }

        public async Task AddAndSave(Studio studio)
        {
            _studioRepo.Add(studio);
            await _studioRepo.Save();
        }

        public async Task UpdateAndSave(Studio studio)
        {
            _studioRepo.Update(studio);
            await _studioRepo.Save();
        }

        public async Task DeleteAndSave(int id)
        {
            _studioRepo.Delete(id);
            await _studioRepo.Save();
        }

        public bool StudioExists(int id)
        {
            return _studioRepo.StudioExists(id);
        }
    }
}
