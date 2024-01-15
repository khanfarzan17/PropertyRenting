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
    public class FavoriteControllerTests
    {
        [Fact]
        public async Task GetFavorite_WithValidUserName_ReturnsOkResult()
        {
            // Arrange
            var mockFavoriteRepo = new Mock<IFavoriteRepo>();
            var rentProperties = new List<RentProperty> { /* Your test data here */ };
            mockFavoriteRepo.Setup(repo => repo.GetAllFavoriteByUserName(It.IsAny<string>())).ReturnsAsync(rentProperties);
            var controller = new FavoriteController(mockFavoriteRepo.Object);

            // Act
            var result = await controller.GetFavorite("testUserName");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedRentProperties = Assert.IsType<List<RentProperty>>(okResult.Value);
            Assert.Equal(rentProperties, returnedRentProperties);
        }

        [Fact]
        public async Task InsertFavorite_WithValidFavorite_ReturnsOkResult()
        {
            // Arrange
            var mockFavoriteRepo = new Mock<IFavoriteRepo>();
            mockFavoriteRepo.Setup(repo => repo.InsertFavorites(It.IsAny<Favorite>())).Returns(Task.CompletedTask);
            var controller = new FavoriteController(mockFavoriteRepo.Object);

            // Act
            var result = await controller.InsertFavorite(new Favorite());

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteFavorite_WithValidFavorite_ReturnsOkResult()
        {
            // Arrange
            var mockFavoriteRepo = new Mock<IFavoriteRepo>();
            mockFavoriteRepo.Setup(repo => repo.DeleteFavorites(It.IsAny<Favorite>())).Returns(Task.CompletedTask);
            var controller = new FavoriteController(mockFavoriteRepo.Object);

            // Act
            var result = await controller.DeleteFavorite(new Favorite());

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
