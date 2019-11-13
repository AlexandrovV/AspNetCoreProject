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
    public class StudioServiceTest
    {
        [Fact]
        public async Task GetAllTest()
        {
            var studios = new List<Studio>
            {
                new Studio() { Name = "Studio One" },
                new Studio() { Name = "Studio Two" }
            };

            var fakeRepositoryMock = new Mock<IStudioRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(studios);

            var studioService = new StudioService(fakeRepositoryMock.Object);

            var resultStudios = await studioService.GetStudios();

            Assert.Collection(resultStudios, studio =>
            {
                Assert.Equal("Studio One", studio.Name);
            },
            studio =>
            {
                Assert.Equal("Studio Two", studio.Name);
            });
        }

        [Fact]
        public async Task GetGenreTest()
        {
            int studioId = 1;
            var studio = new Studio() { StudioId = studioId, Name = "Studio One" };

            var fakeRepositoryMock = new Mock<IStudioRepository>();
            fakeRepositoryMock.Setup(x => x.GetStudio(studioId)).ReturnsAsync(studio);

            var studioService = new StudioService(fakeRepositoryMock.Object);

            var resultStudio = await studioService.GetStudio(studioId);

            Assert.Equal("Studio One", resultStudio.Name);
        }

        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IStudioRepository>();
            var studioService = new StudioService(fakeRepository);

            var studio = new Studio() { Name = "Test Studio" };
            await studioService.AddAndSave(studio);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var fakeRepository = Mock.Of<IStudioRepository>();
            var studioService = new StudioService(fakeRepository);

            var studio = new Studio() { Name = "Test Studio" };
            await studioService.UpdateAndSave(studio);
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IStudioRepository>();
            var studioService = new StudioService(fakeRepository);

            int studioId = 1;
            await studioService.DeleteAndSave(studioId);
        }

        [Fact]
        public void DirectorExistsTest()
        {
            int studioId = 1;

            var fakeRepositoryMock = new Mock<IStudioRepository>();
            fakeRepositoryMock.Setup(x => x.StudioExists(studioId)).Returns(true);

            var studioService = new StudioService(fakeRepositoryMock.Object);

            var isExist = studioService.StudioExists(studioId);

            Assert.True(isExist);
        }
    }
}
