using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Project_Course_Submission.Controllers;
using Project_Course_Submission.Services;

namespace Project_Course_Submission.Tests.UnitTests;

public class LogoutController_Tests
{
    private readonly Mock<IAuthService> _authService;
    private readonly LoginController _loginController;
    public LogoutController_Tests()
    {
        _authService = new Mock<IAuthService>();
        _loginController = new LoginController(_authService.Object);
    }

    public async Task Index_Returns_Redirect_When_Logout_Successful()
    {
        // Arrange

        // Act

        // Assert

    }
}
