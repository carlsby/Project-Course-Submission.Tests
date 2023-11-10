using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Course_Submission.Migrations.Data;
using Project_Course_Submission.Services;
using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Tests.UnitTests
{
	public class Categories_Tests
	{
		[Fact]
		public void TestGetCategoryImagesId()
		{
			// Arrange
			var categoriesService = new CategoriesService();

			// Act
			var categoryImages = categoriesService.GetCategoryImagesId();

			// Assert
			Assert.NotNull(categoryImages); // Kontrollera att resultatet inte är null
			Assert.Equal(7, categoryImages.Count); // Kontrollera att det finns 7 kategori-bilder
												   
		}

		[Fact]
		public void TestGetCategoryImages()
		{
			// Arrange
			var categoriesService = new CategoriesService();

			// Act
			var categoryImagesViewModel = categoriesService.GetCategoryImages();

			// Assert
			Assert.NotNull(categoryImagesViewModel);
			Assert.Equal(7, categoryImagesViewModel.CategoryItems.Count());

		}
	}
}
