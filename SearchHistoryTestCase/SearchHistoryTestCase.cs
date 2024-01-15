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
    public class SearchHistoryControllerTests
    {
        [Fact]
        public async Task GetSearchQuery_WithValidUserName_ReturnsOkResult()
        {
            // Arrange
            var mockSearchHistoryRepo = new Mock<ISearchHistoryRepo>();
            var searchQueries = new List<string> { /* Your test data here */ };
            mockSearchHistoryRepo.Setup(repo => repo.OldSearch(It.IsAny<string>())).ReturnsAsync(searchQueries);
            var controller = new SearchHistroyController(mockSearchHistoryRepo.Object);

            // Act
            var result = await controller.GetSearchQuery("testUserName");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedSearchQueries = Assert.IsType<List<string>>(okResult.Value);
            Assert.Equal(searchQueries, returnedSearchQueries);
        }

        [Fact]
        public async Task GetPropertyBySearchQuery_WithValidSearchQuery_ReturnsOkResult()
        {
            // Arrange
            var mockSearchHistoryRepo = new Mock<ISearchHistoryRepo>();
            var rentProperties = new List<RentProperty> { /* Your test data here */ };
            mockSearchHistoryRepo.Setup(repo => repo.SearchRentProperty(It.IsAny<string>())).ReturnsAsync(rentProperties);
            var controller = new SearchHistroyController(mockSearchHistoryRepo.Object);

            // Act
            var result = await controller.GetPropertyBySearchQuery("testSearchQuery");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedRentProperties = Assert.IsType<List<RentProperty>>(okResult.Value);
            Assert.Equal(rentProperties, returnedRentProperties);
        }

        [Fact]
        public async Task Insert_WithValidSearchHistory_ReturnsCreatedResult()
        {
            // Arrange
            var mockSearchHistoryRepo = new Mock<ISearchHistoryRepo>();
            mockSearchHistoryRepo.Setup(repo => repo.InsertSearchHistory(It.IsAny<SearchHistory>())).Returns(Task.CompletedTask);
            var controller = new SearchHistroyController(mockSearchHistoryRepo.Object);

            // Act
            var result = await controller.Insert(new SearchHistory());

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnedSearchHistory = Assert.IsType<SearchHistory>(createdResult.Value);

            // Assert that the Location property contains the expected URI
           
        }

    }
}
