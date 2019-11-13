using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class MovieService
    {
        private readonly IMovieRepository _movieRepo;

        public MovieService(IMovieRepository movieRepo)
        {
            _movieRepo = movieRepo;
        }

        public async Task<List<Movie>> GetMovies()
        {
            return await _movieRepo.GetAll();
        }

        public async Task<Movie> GetMovie(int id)
        {
            return await _movieRepo.GetMovie(id);
        }

        public async Task AddAndSave(Movie movie)
        {
            _movieRepo.Add(movie);
            await _movieRepo.Save();
        }

        public async Task UpdateAndSave(Movie movie)
        {
            _movieRepo.Update(movie);
            await _movieRepo.Save();
        }

        public async Task DeleteAndSave(int id)
        {
            _movieRepo.Delete(id);
            await _movieRepo.Save();
        }

        public bool MovieExists(int id)
        {
            return _movieRepo.MovieExists(id);
        }
    }
}
