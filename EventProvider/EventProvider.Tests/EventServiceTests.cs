using Xunit;
using Moq;
using EventProvider.Controllers;
using EventProvider.Business.Interfaces;
using EventProvider.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventProvider.Tests
{
    public class EventControllerTests
    {
        [Fact]
        public async Task GetEventById_ReturnsOk_WhenEventExists()
        {
            var mockService = new Mock<IEventService>();
            var eventModel = new Event { Id = 1, Name = "Test" };
            mockService.Setup(s => s.GetEventByIdAsync(1)).ReturnsAsync(eventModel);
            var controller = new EventController(mockService.Object);

            var result = await controller.GetEventById(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(eventModel, okResult.Value);
        }

        [Fact]
        public async Task GetEventById_ReturnsNotFound_WhenEventDoesNotExist()
        {
            var mockService = new Mock<IEventService>();
            mockService.Setup(s => s.GetEventByIdAsync(1)).ReturnsAsync((Event?)null);
            var controller = new EventController(mockService.Object);

            var result = await controller.GetEventById(1);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_WhenModelStateInvalidOrIdInvalid()
        {
            var mockService = new Mock<IEventService>();
            var controller = new EventController(mockService.Object);
            controller.ModelState.AddModelError("Name", "Required");
            var form = new EventRegistrationModel { Id = 0 };

            var result = await controller.Create(form);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Create_ReturnsCreated_WhenServiceReturnsTrue()
        {
            var mockService = new Mock<IEventService>();
            var form = new EventRegistrationModel { Id = 1, Name = "Test" };
            mockService.Setup(s => s.CreateEventAsync(form)).ReturnsAsync(true);
            var controller = new EventController(mockService.Object);

            var result = await controller.Create(form);

            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task Create_ReturnsProblem_WhenServiceReturnsFalse()
        {
            var mockService = new Mock<IEventService>();
            var form = new EventRegistrationModel { Id = 1, Name = "Test" };
            mockService.Setup(s => s.CreateEventAsync(form)).ReturnsAsync(false);
            var controller = new EventController(mockService.Object);

            var result = await controller.Create(form);

            Assert.IsType<ObjectResult>(result); // Problem returns ObjectResult
        }

        [Fact]
        public async Task EditProject_ReturnsBadRequest_WhenModelStateInvalidOrIdInvalid()
        {
            var mockService = new Mock<IEventService>();
            var controller = new EventController(mockService.Object);
            controller.ModelState.AddModelError("Name", "Required");
            var form = new EventRegistrationModel { Id = 0 };

            var result = await controller.EditProject(1, form);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task EditProject_ReturnsOk_WhenServiceReturnsTrue()
        {
            var mockService = new Mock<IEventService>();
            var form = new EventRegistrationModel { Id = 1, Name = "Test" };
            mockService.Setup(s => s.EditEventAsync(1, form)).ReturnsAsync(true);
            var controller = new EventController(mockService.Object);

            var result = await controller.EditProject(1, form);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Event got updated", okResult.Value);
        }

        [Fact]
        public async Task EditProject_ReturnsBadRequest_WhenServiceReturnsFalse()
        {
            var mockService = new Mock<IEventService>();
            var form = new EventRegistrationModel { Id = 1, Name = "Test" };
            mockService.Setup(s => s.EditEventAsync(1, form)).ReturnsAsync(false);
            var controller = new EventController(mockService.Object);

            var result = await controller.EditProject(1, form);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("failed to update Event", badRequest.Value);
        }

        [Fact]
        public async Task DeleteEvent_ReturnsOk_WhenServiceReturnsTrue()
        {
            var mockService = new Mock<IEventService>();
            mockService.Setup(s => s.DeleteEventAsync(1)).ReturnsAsync(true);
            var controller = new EventController(mockService.Object);

            var result = await controller.DeleteEvent(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Event got deleted", okResult.Value);
        }

        [Fact]
        public async Task DeleteEvent_ReturnsBadRequest_WhenServiceReturnsFalse()
        {
            var mockService = new Mock<IEventService>();
            mockService.Setup(s => s.DeleteEventAsync(1)).ReturnsAsync(false);
            var controller = new EventController(mockService.Object);

            var result = await controller.DeleteEvent(1);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("failed to delete Event", badRequest.Value);
        }
    }
}