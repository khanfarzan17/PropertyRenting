using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PropertyRentingApi.Controllers;
using RentEaseLibrary.Models;
using Xunit;

namespace PropertyRentingApi.Tests.Controllers
{
    public class UserControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsOkResultWithUsers()
        {
            // Arrange
            var mockUserRepo = new Mock<IUserRepo>();
            var users = new List<User> { /* Your test data here */ };
            mockUserRepo.Setup(repo => repo.GetAllUser()).ReturnsAsync(users);
            var controller = new UserController(mockUserRepo.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUsers = Assert.IsType<List<User>>(okResult.Value);
            Assert.Equal(users, returnedUsers);
        }

        [Fact]
        public async Task GetByUserNameWithExistingUserReturnsOkResultWithUser()
        {
            // Arrange
            var mockUserRepo = new Mock<IUserRepo>();
            var user = new User { /* Your test data here */ };
            mockUserRepo.Setup(repo => repo.GetUserByUserName(It.IsAny<string>())).ReturnsAsync(user);
            var controller = new UserController(mockUserRepo.Object);

            // Act
            var result = await controller.GetByUserName("testUsername");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUser = Assert.IsType<User>(okResult.Value);
            Assert.Equal(user, returnedUser);
        }

        [Fact]
        public async Task GetByUserName_WithExistingUser_ReturnsOkResultWithUser()
        {
            // Arrange
            var mockUserRepo = new Mock<IUserRepo>();
            var user = new User { /* Your test data here */ };
            mockUserRepo.Setup(repo => repo.GetUserByUserName(It.IsAny<string>())).ReturnsAsync(user);
            var controller = new UserController(mockUserRepo.Object);

            // Act
            var result = await controller.GetByUserName("testUsername");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUser = Assert.IsType<User>(okResult.Value);
            Assert.Equal(user, returnedUser);
        }

        [Fact]
        public async Task Login_WithValidUser_ReturnsOkResult()
        {
            // Arrange
            var mockUserRepo = new Mock<IUserRepo>();
            mockUserRepo.Setup(repo => repo.Login(It.IsAny<User>()));
            var controller = new UserController(mockUserRepo.Object);

            // Act
            var result = await controller.Login(new User());

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Login Suscccesfull", okResult.Value);
        }

        [Fact]
        public async Task Login_WithInvalidUser_ReturnsException()
        {
            // Arrange
            var mockUserRepo = new Mock<IUserRepo>();
            mockUserRepo.Setup(repo => repo.Login(It.IsAny<User>())).ThrowsAsync(new Exception("Login Failed"));
            var controller = new UserController(mockUserRepo.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => controller.Login(new User()));
        }

        [Fact]
        public async Task InsertUser_WithValidUser_ReturnsCreatedResult()
        {
            // Arrange
            var mockUserRepo = new Mock<IUserRepo>();
            mockUserRepo.Setup(repo => repo.InsertUser(It.IsAny<User>())).Returns(Task.CompletedTask);
            var controller = new UserController(mockUserRepo.Object);

            // Act
            var result = await controller.InsertUser(new User() { UserName = "testUserName" });

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);

        }


        [Fact]
        public async Task DelteUser_WithValidUsername_ReturnsOkResult()
        {
            // Arrange
            var mockUserRepo = new Mock<IUserRepo>();
            mockUserRepo.Setup(repo => repo.DeleteUserByUserName(It.IsAny<string>())).Returns(Task.CompletedTask);
            var controller = new UserController(mockUserRepo.Object);

            // Act
            var result = await controller.DelteUser("testUsername");

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
