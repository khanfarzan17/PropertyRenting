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
    public class RentPropertiesControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsOkResultWithRentProperties()
        {
            // Arrange
            var mockRentRepo = new Mock<IRentPropertRepo>();
            var rentProperties = new List<RentProperty> { /* Your test data here */ };
            mockRentRepo.Setup(repo => repo.GetAllProperty()).ReturnsAsync(rentProperties);
            var controller = new RentPropertiesController(mockRentRepo.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedRentProperties = Assert.IsType<List<RentProperty>>(okResult.Value);
            Assert.Equal(rentProperties, returnedRentProperties);
        }

        [Fact]
        public async Task GetByPropertyId_WithExistingProperty_ReturnsOkResultWithProperty()
        {
            // Arrange
            var mockRentRepo = new Mock<IRentPropertRepo>();
            var rentProperty = new RentProperty { /* Your test data here */ };
            mockRentRepo.Setup(repo => repo.GetPropertyById(It.IsAny<int>())).ReturnsAsync(rentProperty);
            var controller = new RentPropertiesController(mockRentRepo.Object);

            // Act
            var result = await controller.GetByPropertyId(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedRentProperty = Assert.IsType<RentProperty>(okResult.Value);
            Assert.Equal(rentProperty, returnedRentProperty);
        }

        [Fact]
        public async Task GetByPropertyId_WithNonExistingProperty_ReturnsNotFoundResult()
        {
            // Arrange
            var mockRentRepo = new Mock<IRentPropertRepo>();
            mockRentRepo.Setup(repo => repo.GetPropertyById(It.IsAny<int>())).ThrowsAsync(new Exception("Property not found"));
            var controller = new RentPropertiesController(mockRentRepo.Object);

            // Act
            var result = await controller.GetByPropertyId(123);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Property not found", notFoundResult.Value);
        }

        [Fact]
        public async Task InsertProperty_WithValidProperty_ReturnsCreatedResult()
        {
            // Arrange
            var mockRentRepo = new Mock<IRentPropertRepo>();
            mockRentRepo.Setup(repo => repo.InsertRentProperty(It.IsAny<RentProperty>())).Returns(Task.CompletedTask);
            var controller = new RentPropertiesController(mockRentRepo.Object);

            // Act
            var result = await controller.InsertProperty(new RentProperty() { PropertyId = 1 });

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            var returnedRentProperty = Assert.IsType<RentProperty>(createdResult.Value);

            // Assert that the Location property contains the expected URI
            Assert.Contains("api/property/1", createdResult.Location.ToString(), StringComparison.OrdinalIgnoreCase);
        }


        [Fact]
        public async Task DeleteProperty_WithValidPropertyId_ReturnsOkResult()
        {
            // Arrange
            var mockRentRepo = new Mock<IRentPropertRepo>();
            mockRentRepo.Setup(repo => repo.DeleteRentProperty(It.IsAny<int>())).Returns(Task.CompletedTask);
            var controller = new RentPropertiesController(mockRentRepo.Object);

            // Act
            var result = await controller.DeleteProperty(1);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateProperty_WithValidProperty_ReturnsOkResult()
        {
            // Arrange
            var mockRentRepo = new Mock<IRentPropertRepo>();
            mockRentRepo.Setup(repo => repo.UpdateRentProperty(It.IsAny<int>(), It.IsAny<RentProperty>())).Returns(Task.CompletedTask);
            var controller = new RentPropertiesController(mockRentRepo.Object);

            // Act
            var result = await controller.UpdateProperty(1, new RentProperty() { PropertyId = 1 });

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
