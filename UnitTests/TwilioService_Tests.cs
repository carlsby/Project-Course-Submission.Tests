using Moq;
using Project_Course_Submission.Controllers;
using Project_Course_Submission.Enums;
using Project_Course_Submission.Models;
using Project_Course_Submission.Services;
using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Tests.UnitTests;

public class TwilioService_Tests
{
    private readonly Mock<ITwilioService> _twilioService;

    public TwilioService_Tests()
    {
        _twilioService = new Mock<ITwilioService>();
    }

    [Fact]
    public async Task SendTextVerification_ShouldRedirectToOTP_WhenStatusCode200()
    {
        // Arrange
        var model = new PhoneNumberViewModel
        {
            PhoneNumber = "0701234567",
            TextMessage = "Test"
        };

        var response = new ServiceResponse<PhoneNumberViewModel>
        {
            StatusCode = StatusCode.Ok,
            Content = model
        };

        _twilioService.Setup(x => x.SendTextVerification(model)).ReturnsAsync(response);
        var twilioService = _twilioService.Object;


        // Act
        var result = await twilioService.SendTextVerification(model);


        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCode.Ok, result.StatusCode);
        Assert.Equal(model, result.Content);
    }
}
