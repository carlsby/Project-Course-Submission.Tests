using Microsoft.EntityFrameworkCore;
using Project_Course_Submission.Contexts;
using Project_Course_Submission.Services;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Course_Submission.Models.Entities;

namespace Project_Course_Submission.Tests.UnitTest
{
    public class ReviewService_Tests
    {
        [Fact]
        public async Task GetAllAsync_Returns_Reviews()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new DataContext(options))
            {
                // Skapa en in-memory-databas och lägg till testdata
                context.Reviews.Add(new ReviewEntity { Id = 1, CommentCreated = DateTime.Now, Rating = 5, Comment = "Test Review 1" });
                context.Reviews.Add(new ReviewEntity { Id = 2, CommentCreated = DateTime.Now, Rating = 4, Comment = "Test Review 2" });
                context.SaveChanges();
            }

            using (var context = new DataContext(options))
            {
                var service = new ReviewService(context);

                // Act
                var result = await service.GetAllAsync();

                // Assert
                Assert.Equal(2, result.Count()); 
            }
        }

    }
}
