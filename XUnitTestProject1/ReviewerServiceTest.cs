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
    public class ReviewerServiceTest
    {
        [Fact]
        public async Task GetAllTest()
        {
            var reviewers = new List<Reviewer>
            {
                new Reviewer() { Name = "Reviewer One" },
                new Reviewer() { Name = "Reviewer Two" }
            };

            var fakeRepositoryMock = new Mock<IReviewerRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(reviewers);

            var reviewerService = new ReviewerService(fakeRepositoryMock.Object);

            var resultReviewers = await reviewerService.GetReviewers();

            Assert.Collection(resultReviewers, reviewer =>
            {
                Assert.Equal("Reviewer One", reviewer.Name);
            },
            reviewer =>
            {
                Assert.Equal("Reviewer Two", reviewer.Name);
            });
        }

        [Fact]
        public async Task GetDirectorTest()
        {
            int reviewerId = 1;
            var director = new Reviewer() { ReviewerId = reviewerId, Name = "Reviewer One" };

            var fakeRepositoryMock = new Mock<IReviewerRepository>();
            fakeRepositoryMock.Setup(x => x.GetReviewer(reviewerId)).ReturnsAsync(director);

            var reviewerService = new ReviewerService(fakeRepositoryMock.Object);

            var resultReviewer = await reviewerService.GetReviewer(reviewerId);

            Assert.Equal("Reviewer One", resultReviewer.Name);
        }

        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IReviewerRepository>();
            var reviewerService = new ReviewerService(fakeRepository);

            var reviewer = new Reviewer() { Name = "Test Reviewer" };
            await reviewerService.AddAndSave(reviewer);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var fakeRepository = Mock.Of<IReviewerRepository>();
            var reviewerService = new ReviewerService(fakeRepository);

            var reviewer = new Reviewer() { Name = "Test Reviewer" };
            await reviewerService.UpdateAndSave(reviewer);
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IReviewerRepository>();
            var reviewerService = new ReviewerService(fakeRepository);

            int reviewerId = 1;
            await reviewerService.DeleteAndSave(reviewerId);
        }

        [Fact]
        public void DirectorExistsTest()
        {
            int directorId = 1;

            var fakeRepositoryMock = new Mock<IReviewerRepository>();
            fakeRepositoryMock.Setup(x => x.ReviewerExists(directorId)).Returns(true);

            var reviewerService = new ReviewerService(fakeRepositoryMock.Object);

            var isExist = reviewerService.ReviewerExists(directorId);

            Assert.True(isExist);
        }
    }
}
