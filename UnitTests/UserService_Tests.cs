using Microsoft.EntityFrameworkCore;
using Moq;
using Project_Course_Submission.Contexts;
using Project_Course_Submission.Models;
using Project_Course_Submission.Models.Entities;
using Project_Course_Submission.Services;
using System.Linq.Expressions;

namespace Project_Course_Submission.Tests.UnitTests;

public class UserService_Tests
{
    private readonly Mock<IUserService> _userServiceMock;

    public UserService_Tests()
    {
        _userServiceMock = new Mock<IUserService>();
    }

    [Fact]
    public async Task GetUserProfileAsync_ShouldReturnStatusCode200_WhenValidUserIsFound()
    {
        // Arrange
        var userId = "validId";
        var userProfileEntity = new UserProfileEntity
        {
            UserId = userId,
        };

        var response = new ServiceResponse<UserProfileEntity>
        {
            StatusCode = Enums.StatusCode.Ok,
            Content = userProfileEntity
        };

        _userServiceMock.Setup(x => x.GetUserProfileAsync(userId)).ReturnsAsync(response);

        var userService = _userServiceMock.Object;

        // Act
        var result = await userService.GetUserProfileAsync(userId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(Enums.StatusCode.Ok, result.StatusCode);
        Assert.Equal(userProfileEntity, result.Content);
    }

    [Fact]
    public async Task GetUserProfileAsync_ShouldReturnStatusCode404_WhenUserIsNotFound()
    {
        // Arrange
        var userId = "notValidId";

        var response = new ServiceResponse<UserProfileEntity>
        {
            StatusCode = Enums.StatusCode.Notfound,
            Content = null
        };

        _userServiceMock.Setup(x => x.GetUserProfileAsync(userId)).ReturnsAsync(response);

        var userService = _userServiceMock.Object;

        // Act
        var result = await userService.GetUserProfileAsync(userId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(Enums.StatusCode.Notfound, result.StatusCode);
        Assert.Null(result.Content);
    }

    [Fact]
    public async Task GetAsync_ShouldReturnStatusCodeOk_WhenUserIsFound()
    {
        // Arrange
        var entity = new UserProfileEntity
        {
            FirstName = "Test",
            LastName = "Testsson",
        };

        var response = new ServiceResponse<UserProfileEntity>
        {
            Content = entity,
            StatusCode = Enums.StatusCode.Ok
        };

        _userServiceMock.Setup(x => x.GetAsync(It.IsAny<Expression<Func<UserProfileEntity, bool>>>())).ReturnsAsync(response);

        var userService = _userServiceMock.Object;

        // Act
        var result = await userService.GetAsync(x => x.FirstName == "Test" && x.LastName == "Testsson");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(Enums.StatusCode.Ok, result.StatusCode);
        Assert.Equal(entity.FirstName, result.Content!.FirstName);
        Assert.Equal(entity.LastName, result.Content.LastName);
    }


    [Fact]
    public async Task GetAsync_ShouldReturnStatusCodeBadRequest_WhenUserIsNotFound()
    {
        // Arrange
        var response = new ServiceResponse<UserProfileEntity>
        {
            Content = null,
            StatusCode = Enums.StatusCode.BadRequest
        };

        _userServiceMock.Setup(x => x.GetAsync(It.IsAny<Expression<Func<UserProfileEntity, bool>>>())).ReturnsAsync(response);

        var userService = _userServiceMock.Object;

        // Act
        var result = await userService.GetAsync(x => x.FirstName == "Carl" && x.LastName == "Andersson");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(Enums.StatusCode.BadRequest, result.StatusCode);
    }

}
