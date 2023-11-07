using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Course_Submission.Services;

namespace Project_Course_Submission.Tests.UnitTests
{
	public class FeaturedProducts_Tests
	{
		[Fact]
		public void TestGetFeaturedProducts()
		{
			// Arrange
			var featuredProductsService = new FeaturedProductsService();

			// Act
			var featuredProducts = featuredProductsService.GetFeaturedProducts();
			var featuredItemsList = featuredProducts.FeaturedItems.ToList(); 

			// Assert
			Assert.NotNull(featuredProducts);
			Assert.Equal("Featured Products", featuredProducts.Title);
			Assert.Equal("View All", featuredProducts.Ingress);
			Assert.NotNull(featuredItemsList);
			Assert.Equal(7, featuredItemsList.Count);
			Assert.Equal("1", featuredItemsList[0].Id);
			Assert.Equal("Christmas Tree, Green", featuredItemsList[0].Title);
            Assert.Equal("Verklighetstrogen julgran i mörkgrön färg. 200 cm hög.", featuredItemsList[0].Description);
            Assert.Equal(300, featuredItemsList[0].Price);
            Assert.Equal("/images/featured/200x122.svg", featuredItemsList[0].ImageUrl);
        }
	}
}
