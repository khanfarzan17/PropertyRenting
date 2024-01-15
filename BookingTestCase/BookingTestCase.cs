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
    public class BookingControllerTests
    {
        [Fact]
        public async Task GetAllBookings_ReturnsOkResultWithBookings()
        {
            // Arrange
            var mockBookingRepo = new Mock<IBookingRepo>();
            var bookings = new List<Booking> { /* Your test data here */ };
            mockBookingRepo.Setup(repo => repo.GetAllBooking()).ReturnsAsync(bookings);
            var controller = new BookingController(mockBookingRepo.Object);

            // Act
            var result = await controller.GetAllBookings();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedBookings = Assert.IsType<List<Booking>>(okResult.Value);
            Assert.Equal(bookings, returnedBookings);
        }

        [Fact]
        public async Task GetBookingByUserName_WithExistingBooking_ReturnsOkResultWithBooking()
        {
            // Arrange
            var mockBookingRepo = new Mock<IBookingRepo>();
            var booking = new Booking { /* Your test data here */ };
            mockBookingRepo.Setup(repo => repo.GetBookingByUserName(It.IsAny<string>())).ReturnsAsync(booking);
            var controller = new BookingController(mockBookingRepo.Object);

            // Act
            var result = await controller.GetBookingByUserName("testUsername");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedBooking = Assert.IsType<Booking>(okResult.Value);
            Assert.Equal(booking, returnedBooking);
        }

        [Fact]
        public async Task GetBookingByUserName_WithNonExistingBooking_ReturnsException()
        {
            // Arrange
            var mockBookingRepo = new Mock<IBookingRepo>();
            mockBookingRepo.Setup(repo => repo.GetBookingByUserName(It.IsAny<string>())).ThrowsAsync(new Exception("No such Booking is Being Found to that Username"));
            var controller = new BookingController(mockBookingRepo.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => controller.GetBookingByUserName("nonExistingUsername"));
        }

        [Fact]
        public async Task GetBookingById_WithExistingBooking_ReturnsOkResultWithBooking()
        {
            // Arrange
            var mockBookingRepo = new Mock<IBookingRepo>();
            var booking = new Booking { /* Your test data here */ };
            mockBookingRepo.Setup(repo => repo.GetBookingById(It.IsAny<int>())).ReturnsAsync(booking);
            var controller = new BookingController(mockBookingRepo.Object);

            // Act
            var result = await controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedBooking = Assert.IsType<Booking>(okResult.Value);
            Assert.Equal(booking, returnedBooking);
        }

        [Fact]
        public async Task GetBookingById_WithNonExistingBooking_ReturnsException()
        {
            // Arrange
            var mockBookingRepo = new Mock<IBookingRepo>();
            mockBookingRepo.Setup(repo => repo.GetBookingById(It.IsAny<int>())).ThrowsAsync(new Exception("No such Booking Id is Found"));
            var controller = new BookingController(mockBookingRepo.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => controller.GetById(123));
        }

        [Fact]
        public async Task InsertBooking_WithValidBooking_ReturnsCreatedResult()
        {
            // Arrange
            var mockBookingRepo = new Mock<IBookingRepo>();
            mockBookingRepo.Setup(repo => repo.InsertBooking(It.IsAny<Booking>())).Returns(Task.CompletedTask);
            var controller = new BookingController(mockBookingRepo.Object);

            // Act
            var result = await controller.InsertBooking(new Booking() { BookingID = 1 });

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            var returnedBooking = Assert.IsType<Booking>(createdResult.Value);

            // Assert that the Location property contains the expected URI
            Assert.Contains("api/booking/1", createdResult.Location.ToString(), StringComparison.OrdinalIgnoreCase);
        }


        [Fact]
        public async Task DeleteBooking_WithValidBookingId_ReturnsOkResult()
        {
            // Arrange
            var mockBookingRepo = new Mock<IBookingRepo>();
            mockBookingRepo.Setup(repo => repo.DeleteBooking(It.IsAny<int>())).Returns(Task.CompletedTask);
            var controller = new BookingController(mockBookingRepo.Object);

            // Act
            var result = await controller.DeleteBooking(1);

            // Assert
            Assert.IsType<OkResult>(result);
        }



    }
}
