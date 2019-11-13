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
    public class GenreServiceTest
    {
        [Fact]
        public async Task GetAllTest()
        {
            var genres = new List<Genre>
            {
                new Genre() { Name = "Genre One" },
                new Genre() { Name = "Genre Two" }
            };

            var fakeRepositoryMock = new Mock<IGenreRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(genres);

            var genreService = new GenreService(fakeRepositoryMock.Object);

            var resultGenres = await genreService.GetGenres();

            Assert.Collection(resultGenres, genre =>
            {
                Assert.Equal("Genre One", genre.Name);
            },
            genre =>
            {
                Assert.Equal("Genre Two", genre.Name);
            });
        }

        [Fact]
        public async Task GetGenreTest()
        {
            int genreId = 1;
            var genre = new Genre() { GenreId = genreId, Name = "Genre One" };

            var fakeRepositoryMock = new Mock<IGenreRepository>();
            fakeRepositoryMock.Setup(x => x.GetGenre(genreId)).ReturnsAsync(genre);

            var genreService = new GenreService(fakeRepositoryMock.Object);

            var resultGenre = await genreService.GetGenre(genreId);

            Assert.Equal("Genre One", resultGenre.Name);
        }

        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IGenreRepository>();
            var genreService = new GenreService(fakeRepository);

            var genre = new Genre() { Name = "Test Genre" };
            await genreService.AddAndSave(genre);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var fakeRepository = Mock.Of<IGenreRepository>();
            var genreService = new GenreService(fakeRepository);

            var genre = new Genre() { Name = "Test Genre" };
            await genreService.UpdateAndSave(genre);
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IGenreRepository>();
            var genreService = new GenreService(fakeRepository);

            int genreId = 1;
            await genreService.DeleteAndSave(genreId);
        }

        [Fact]
        public void DirectorExistsTest()
        {
            int genreId = 1;

            var fakeRepositoryMock = new Mock<IGenreRepository>();
            fakeRepositoryMock.Setup(x => x.GenreExists(genreId)).Returns(true);

            var genreService = new GenreService(fakeRepositoryMock.Object);

            var isExist = genreService.GenreExists(genreId);

            Assert.True(isExist);
        }
    }
}
