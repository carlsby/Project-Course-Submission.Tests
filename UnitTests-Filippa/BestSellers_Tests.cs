
using Project_Course_Submission.Services;

namespace Project_Course_Submission.Tests.UnitTests;

public class BestSellers_Tests
{
	[Fact]
	public void TestGetBestSellers()
	{
		// Arrange
		var bestSellersService = new BestSellersService();

		// Act
		var bestSellers = bestSellersService.GetBestSellers();
		var bestItemsList = bestSellers.BestItems.ToList(); // Konvertera till en lista

		// Assert
		Assert.NotNull(bestSellers);
		Assert.Equal("Best Sellers", bestSellers.Title);
		Assert.Equal("View All", bestSellers.Ingress);
		Assert.NotNull(bestItemsList);
		Assert.Equal(7, bestItemsList.Count);
		Assert.Equal("1", bestItemsList[0].Id);	
		Assert.Equal("/images/bestsellers/270x295.svg", bestItemsList[0].ImageUrl);
		Assert.Equal("Soft Chill Pants", bestItemsList[0].Title);
		Assert.Equal("Stretchigt, mjukt material. Vikning i midjan, utsvängda byxben.", bestItemsList[0].Description);
		Assert.Equal(40, bestItemsList[0].Price);
	

    }
}
