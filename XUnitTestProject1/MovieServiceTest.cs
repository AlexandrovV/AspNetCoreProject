using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;
using Xunit;

namespace XUnitTestProject1
{
    public class MovieServiceTest
    {
        [Fact]
        public async Task GetAllTest()
        {
            var movies = new List<Movie>
            {
                new Movie() { Name = "Movie One" },
                new Movie() { Name = "Movie Two" }
            };

            var fakeRepositoryMock = new Mock<IMovieRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(movies);

            var movieService = new MovieService(fakeRepositoryMock.Object);

            var resultMovies = await movieService.GetMovies();

            Assert.Collection(resultMovies, movie =>
            {
                Assert.Equal("Movie One", movie.Name);
            },
            movie =>
            {
                Assert.Equal("Movie Two", movie.Name);
            });
        }

        [Fact]
        public async Task GetMovieTest()
        {
            int movieId = 1;
            var movie = new Movie() { MovieId = movieId, Name = "Movie One" };

            var fakeRepositoryMock = new Mock<IMovieRepository>();
            fakeRepositoryMock.Setup(x => x.GetMovie(movieId)).ReturnsAsync(movie);

            var movieService = new MovieService(fakeRepositoryMock.Object);

            var resultMovie = await movieService.GetMovie(movieId);

            Assert.Equal("Movie One", resultMovie.Name);
        }

        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IMovieRepository>();
            var directorService = new MovieService(fakeRepository);

            var movie = new Movie() { Name = "Test Movie" };
            await directorService.AddAndSave(movie);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var fakeRepository = Mock.Of<IMovieRepository>();
            var movieService = new MovieService(fakeRepository);

            var movie = new Movie() { Name = "Test Movie" };
            await movieService.UpdateAndSave(movie);
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IMovieRepository>();
            var movieService = new MovieService(fakeRepository);

            int movieId = 1;
            await movieService.DeleteAndSave(movieId);
        }

        [Fact]
        public void DirectorExistsTest()
        {
            int movieId = 1;

            var fakeRepositoryMock = new Mock<IMovieRepository>();
            fakeRepositoryMock.Setup(x => x.MovieExists(movieId)).Returns(true);

            var movieService = new MovieService(fakeRepositoryMock.Object);

            var isExist = movieService.MovieExists(movieId);

            Assert.True(isExist);
        }
    }
}
