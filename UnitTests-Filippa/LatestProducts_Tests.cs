using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Course_Submission.Services;
using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Tests.UnitTests
{
    public class LatestProducts_Tests
    {
        [Fact]
        public void GetLatestProducts_ReturnsExpectedData()
        {
            // Arrange
            var latestProductsService = new LatestProductsService(); 

            // Act
            var latestProducts = latestProductsService.GetLatestProducts();
            var latestItemsList = latestProducts.LatestItems.ToList();
            // Assert
            Assert.NotNull(latestProducts);
            Assert.IsType<LatestProductsViewModel>(latestProducts);

       
            Assert.NotNull(latestItemsList);
            Assert.Equal(3, latestItemsList.Count);
            Assert.Equal("1", latestItemsList[0].Id);
            Assert.Equal("Welcome To Manero", latestItemsList[0].Title);
            Assert.Equal("Shop Now", latestItemsList[0].ButtonUrl);
            Assert.Equal("/images/softpants.jpg", latestItemsList[0].ImageUrl);
          
        }
    }
}
