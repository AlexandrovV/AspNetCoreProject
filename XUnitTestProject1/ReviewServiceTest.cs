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
    public class ReviewServiceTest
    {
        [Fact]
        public async Task GetAllTest()
        {
            var reviews = new List<Review>
            {
                new Review() { Text = "Review One" },
                new Review() { Text = "Review Two" }
            };

            var fakeRepositoryMock = new Mock<IReviewRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(reviews);

            var movieService = new ReviewService(fakeRepositoryMock.Object);

            var resultReviews = await movieService.GetReviews();

            Assert.Collection(resultReviews, review =>
            {
                Assert.Equal("Review One", review.Text);
            },
            review =>
            {
                Assert.Equal("Review Two", review.Text);
            });
        }

        [Fact]
        public async Task GetMovieTest()
        {
            int reviewId = 1;
            var review = new Review() { ReviewId = reviewId, Text = "Review One" };

            var fakeRepositoryMock = new Mock<IReviewRepository>();
            fakeRepositoryMock.Setup(x => x.GetReview(reviewId)).ReturnsAsync(review);

            var reviewService = new ReviewService(fakeRepositoryMock.Object);

            var resultMovie = await reviewService.GetReview(reviewId);

            Assert.Equal("Review One", resultMovie.Text);
        }

        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IReviewRepository>();
            var reviewService = new ReviewService(fakeRepository);

            var review = new Review() { Text = "Test Review" };
            await reviewService.AddAndSave(review);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var fakeRepository = Mock.Of<IReviewRepository>();
            var reviewService = new ReviewService(fakeRepository);

            var review = new Review() { Text = "Test Review" };
            await reviewService.UpdateAndSave(review);
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IReviewRepository>();
            var movieService = new ReviewService(fakeRepository);

            int reviewId = 1;
            await movieService.DeleteAndSave(reviewId);
        }

        [Fact]
        public void DirectorExistsTest()
        {
            int reviewId = 1;

            var fakeRepositoryMock = new Mock<IReviewRepository>();
            fakeRepositoryMock.Setup(x => x.ReviewExists(reviewId)).Returns(true);

            var reviewService = new ReviewService(fakeRepositoryMock.Object);

            var isExist = reviewService.ReviewExists(reviewId);

            Assert.True(isExist);
        }
    }
}
