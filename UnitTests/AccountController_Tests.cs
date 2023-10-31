using Moq;
using Project_Course_Submission.Controllers;
using Project_Course_Submission.Enums;
using Project_Course_Submission.Models;
using Project_Course_Submission.Models.Entities;
using Project_Course_Submission.Services;
using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Tests.UnitTests;
public class AccountController_Tests
{
    private readonly AccountController _accountController;
    private readonly Mock<ITwilioService> _twilioService;
    private readonly Mock<IUserService> _userService;

    public AccountController_Tests()
    {
        _twilioService = new Mock<ITwilioService>();
        _userService = new Mock<IUserService>();
        _accountController = new AccountController(_userService.Object, _twilioService.Object);
    }


}
