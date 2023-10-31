using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using Project_Course_Submission.Contexts;
using Project_Course_Submission.Enums;
using Project_Course_Submission.Models;
using Project_Course_Submission.Models.Entities;
using Project_Course_Submission.Services;
using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Tests.UnitTests;

public class AuthService_Tests
{
    private readonly Mock<IAuthService> _authServiceMock;

    public AuthService_Tests()
    {
        _authServiceMock = new Mock<IAuthService>();
    }

    [Fact]
    public async Task RegisterAsync_ShouldReturnStatusCode200_AndTrue_WhenSuccessfulRegistration()
    {
        // Arrange

        var user = new UserRegisterViewModel()
        {
            Email = "test@test.com",
            Password = "Test123!",
            ConfirmPassword = "Test123!",
            FirstName = "Test",
            LastName = "Testsson",
        };

        var response = new ServiceResponse<bool>
        {
            StatusCode = StatusCode.Created,
            Content = true,
        };

        _authServiceMock.Setup(x => x.RegisterAsync(It.IsAny<UserRegisterViewModel>())).ReturnsAsync(response);

        // Act
        var result = await _authServiceMock.Object.RegisterAsync(user);

        // Assert
        Assert.True(result.Content);
        Assert.Equal(StatusCode.Created, result.StatusCode);
    }

    [Fact]
    public async Task RegisterAsync_ShouldReturnStatusCode400_AndFalse_WhenUnsuccessfulRegistration()
    {
        // Arrange

        var user = new UserRegisterViewModel()
        {
            Email = "",
            Password = "",
            ConfirmPassword = "",
            FirstName = "",
            LastName = "",
        };

        var response = new ServiceResponse<bool>
        {
            StatusCode = StatusCode.BadRequest,
            Content = false,
        };

        _authServiceMock.Setup(x => x.RegisterAsync(It.IsAny<UserRegisterViewModel>())).ReturnsAsync(response);

        // Act
        var result = await _authServiceMock.Object.RegisterAsync(user);

        // Assert
        Assert.False(result.Content);
        Assert.Equal(StatusCode.BadRequest, result.StatusCode);
    }


}
