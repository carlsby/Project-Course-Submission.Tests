using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Project_Course_Submission.Controllers;
using Project_Course_Submission.Contexts;
using Project_Course_Submission.Models.Entities;
using Project_Course_Submission.ViewModels;
using Xunit;
using NuGet.ContentModel;

namespace Project_Course_Submission.Tests.Controllers
{
    public class WishlistControllerTests
    {
        [Fact]
        public void Wishlist_ReturnsViewResult_WithWishlistItems()
        {

            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new DataContext(options))
            {
           
                var userId = "123"; 
                context.Wishlist.Add(new WishlistsEntity
                {
                    Id = 1,
                    ProductTitle = "Test Product",
                    ProductImg = "test-image.jpg",
                    ProductPrice = "99.99",
                    ProductReview = "4.5",
                    ProductReviewRate = 4,
                    ProductsArticleNumber = "ABC123",
                    UserId = userId
                });
                context.SaveChanges();
            }

            var controller = new WishlistController(new DataContext(options));

            var userClaim = new Claim(ClaimTypes.NameIdentifier, "123"); 
            var httpContext = new DefaultHttpContext();
            httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> { userClaim }));

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };

            // Act
            var result = controller.Wishlist() as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = result.Model as List<WishlistViewModel>;
            Assert.NotNull(model);
            Assert.NotEmpty(model);

        }
    }
}