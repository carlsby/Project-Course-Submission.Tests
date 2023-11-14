using Microsoft.AspNetCore.Mvc;
using Project_Course_Submission.Controllers;
using Xunit;

namespace Project_Course_Submission.Tests
{
    public class OrderTrackingControllerTests
    {
        [Fact]
        public void TrackingAction_ReturnsNonNullViewResult()
        {
            // Arrange
            var context = // Initialize your DataContext or use a mock here
            var controller = new OrderTrackingController(context);

            // Act
            var result = controller.Tracking(orderId: 123); // Provide a valid order ID

            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}