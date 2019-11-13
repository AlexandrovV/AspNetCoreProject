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
    public class DirectorServiceTest
    {
        [Fact]
        public async Task GetAllTest()
        {
            var directors = new List<Director>
            {
                new Director() { Name = "Director One" },
                new Director() { Name = "Director Two" }
            };

            var fakeRepositoryMock = new Mock<IDirectorRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(directors);

            var actorService = new DirectorService(fakeRepositoryMock.Object);

            var resultDirectors = await actorService.GetDirectors();

            Assert.Collection(resultDirectors, director =>
            {
                Assert.Equal("Director One", director.Name);
            },
            director =>
            {
                Assert.Equal("Director Two", director.Name);
            });
        }

        [Fact]
        public async Task GetDirectorTest()
        {
            int directorId = 1;
            var director = new Director() { DirectorId = directorId, Name = "Director One" };

            var fakeRepositoryMock = new Mock<IDirectorRepository>();
            fakeRepositoryMock.Setup(x => x.GetDirector(directorId)).ReturnsAsync(director);

            var actorService = new DirectorService(fakeRepositoryMock.Object);

            var resultDirector = await actorService.GetDirector(directorId);

            Assert.Equal("Director One", resultDirector.Name);
        }

        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IDirectorRepository>();
            var directorService = new DirectorService(fakeRepository);

            var director = new Director() { Name = "Test Director" };
            await directorService.AddAndSave(director);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var fakeRepository = Mock.Of<IDirectorRepository>();
            var directorService = new DirectorService(fakeRepository);

            var director = new Director() { Name = "Test Director" };
            await directorService.UpdateAndSave(director);
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IDirectorRepository>();
            var directorService = new DirectorService(fakeRepository);

            int directorId = 1;
            await directorService.DeleteAndSave(directorId);
        }

        [Fact]
        public void DirectorExistsTest()
        {
            int directorId = 1;

            var fakeRepositoryMock = new Mock<IDirectorRepository>();
            fakeRepositoryMock.Setup(x => x.DirectorExists(directorId)).Returns(true);

            var actorService = new DirectorService(fakeRepositoryMock.Object);

            var isExist = actorService.DirectorExists(directorId);

            Assert.True(isExist);
        }
    }
}
