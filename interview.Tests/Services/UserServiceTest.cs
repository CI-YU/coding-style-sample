using interview.Repository.Interface;
using interview.Services;
using Moq;

namespace interview.Tests.Services;

public class UserServiceTest
{
    [Fact]
    public async Task GetUserById_ReturnsUserObject()
    {
        // Arrange
        var mockUserRepository = new Mock<IUserRepository>();
        var userService = new UserService(mockUserRepository.Object);
        int testId = 1;
        var expectedUser = new { Id = testId, Name = "Test User" };

        mockUserRepository.Setup(repo => repo.GetUserById(testId)).ReturnsAsync(expectedUser);

        // Act
        var result = await userService.GetUserById(testId);

        // Assert
        Assert.Equal(expectedUser, result);
    }

    [Fact]
    public async Task GetUserById_UserNotFound_ReturnsNull()
    {
        // Arrange
        var mockUserRepository = new Mock<IUserRepository>();
        var userService = new UserService(mockUserRepository.Object);
        int testId = 1;

        mockUserRepository.Setup(repo => repo.GetUserById(testId)).ReturnsAsync((object)null);

        // Act
        var result = await userService.GetUserById(testId);

        // Assert
        Assert.Null(result);
    }
}