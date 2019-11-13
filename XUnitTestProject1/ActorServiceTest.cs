using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;
using Xunit;

namespace XUnitTestProject1
{
    public class ActorServiceTest
    {
        [Fact]
        public async Task GetAllTest()
        {
            var actors = new List<Actor>
            {
                new Actor() { Name = "Actor One" },
                new Actor() { Name = "Actor Two" }
            };

            var fakeRepositoryMock = new Mock<IActorRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(actors);

            var actorService = new ActorService(fakeRepositoryMock.Object);

            var resultActors = await actorService.GetActors();

            Assert.Collection(resultActors, actor =>
            {
                Assert.Equal("Actor One", actor.Name);
            }, 
            actor =>
            { 
                Assert.Equal("Actor Two", actor.Name);
            });
        }

        [Fact]
        public async Task GetActorTest()
        {
            int actorId = 1;
            var actor = new Actor() { ActorId = actorId, Name = "Actor One" };

            var fakeRepositoryMock = new Mock<IActorRepository>();
            fakeRepositoryMock.Setup(x => x.GetActor(actorId)).ReturnsAsync(actor);

            var actorService = new ActorService(fakeRepositoryMock.Object);

            var resultActor = await actorService.GetActor(actorId);

            Assert.Equal("Actor One", resultActor.Name);
        }

        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IActorRepository>();
            var movieService = new ActorService(fakeRepository);

            var actor = new Actor() { Name = "Test Actor" };
            await movieService.AddAndSave(actor);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var fakeRepository = Mock.Of<IActorRepository>();
            var movieService = new ActorService(fakeRepository);

            var actor = new Actor() { Name = "Test Actor" };
            await movieService.UpdateAndSave(actor);
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IActorRepository>();
            var movieService = new ActorService(fakeRepository);

            int actorId = 1;
            await movieService.DeleteAndSave(actorId);
        }

        [Fact]
        public void ActorExistsTest()
        {
            int actorId = 1;

            var fakeRepositoryMock = new Mock<IActorRepository>();
            fakeRepositoryMock.Setup(x => x.ActorExists(actorId)).Returns(true);

            var actorService = new ActorService(fakeRepositoryMock.Object);

            var isExist = actorService.ActorExists(actorId);

            Assert.True(isExist);
        }

        [Fact]
        public void CheckActorNameTest()
        {
            var name = "Vladislav Alexandrov";

            var fakeRepository = Mock.Of<IActorRepository>();
            var movieService = new ActorService(fakeRepository);

            var isNameOk = movieService.CheckActorName(name);

            Assert.False(isNameOk);
        }
    }
}
