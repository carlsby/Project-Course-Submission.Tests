using Microsoft.AspNetCore.Mvc;
using Moq;
using Project_Course_Submission.Controllers;
using Project_Course_Submission.Enums;
using Project_Course_Submission.Models;
using Project_Course_Submission.Services;
using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Tests.UnitTests;

public class LoginController_Tests
{
    private readonly Mock<IAuthService> _authService;
    private readonly LoginController _loginController;

    public LoginController_Tests()
    {
        _authService = new Mock<IAuthService>();
        _loginController = new LoginController(_authService.Object);
    }

    [Fact]
    public async Task Index_ShouldReturnRedirect_WhenModelStateIsValid()
    {
        // Arrange
        var model = new UserLoginViewModel();

        _authService.Setup(x => x.LogInAsync(It.IsAny<UserLoginViewModel>()))
            .ReturnsAsync(new ServiceResponse<bool>
            {
                StatusCode = StatusCode.Ok,
                Content = true
            });

        // Act
        var result = await _loginController.Index(model) as RedirectToActionResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Index", result.ActionName);
        Assert.Equal("Account", result.ControllerName);
    }
}
