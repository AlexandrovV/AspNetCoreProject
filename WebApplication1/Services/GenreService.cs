using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class GenreService
    {
        private readonly IGenreRepository _genreRepo;

        public GenreService(IGenreRepository genreRepo)
        {
            _genreRepo = genreRepo;
        }

        public async Task<List<Genre>> GetGenres()
        {
            return await _genreRepo.GetAll();
        }

        public async Task<Genre> GetGenre(int id)
        {
            return await _genreRepo.GetGenre(id);
        }

        public async Task AddAndSave(Genre genre)
        {
            _genreRepo.Add(genre);
            await _genreRepo.Save();
        }

        public async Task UpdateAndSave(Genre genre)
        {
            _genreRepo.Update(genre);
            await _genreRepo.Save();
        }

        public async Task DeleteAndSave(int id)
        {
            _genreRepo.Delete(id);
            await _genreRepo.Save();
        }

        public bool GenreExists(int id)
        {
            return _genreRepo.GenreExists(id);
        }
    }
}
