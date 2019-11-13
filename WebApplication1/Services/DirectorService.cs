using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class DirectorService
    {
        private readonly IDirectorRepository _directorRepo;

        public DirectorService(IDirectorRepository directorRepo)
        {
            _directorRepo = directorRepo;
        }

        public async Task<List<Director>> GetDirectors()
        {
            return await _directorRepo.GetAll();
        }

        public async Task<Director> GetDirector(int id)
        {
            return await _directorRepo.GetDirector(id);
        }

        public async Task AddAndSave(Director director)
        {
            _directorRepo.Add(director);
            await _directorRepo.Save();
        }

        public async Task UpdateAndSave(Director director)
        {
            _directorRepo.Update(director);
            await _directorRepo.Save();
        }

        public async Task DeleteAndSave(int id)
        {
            _directorRepo.Delete(id);
            await _directorRepo.Save();
        }

        public bool DirectorExists(int id)
        {
            return _directorRepo.DirectorExists(id);
        }
    }
}
