using Microsoft.AspNetCore.Mvc;
using Xunit;
using System;
using System.Collections.Generic;
using Project_Course_Submission.Controllers;

namespace Project_Course_Submission.Tests.UnitTest
{
    public class SearchController_Tests
    {

        [Fact]
        public void Index_ReturnsViewResult_WithNoMatch()
        {
            // Arrange
            var controller = new SearchController();
            var searchText = "InvalidSearchText";

            // Act
            var result = controller.Index(searchText) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var model = result.Model as List<string>;
            Assert.NotNull(model);
            Assert.Single(model); // "Your search didn't match any category."
        }
    }
}
