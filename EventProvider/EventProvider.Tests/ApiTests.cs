using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EventProvider.Tests;
using Xunit;

namespace EventProvider.Tests
{
    public class ApiTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public ApiTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetEvents_ReturnsSuccess()
        {
            var response = await _client.GetAsync("/api/event");
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task GetEventById_ValidId_ReturnsEvent()
        {
            var response = await _client.GetAsync("/api/event/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetEventById_InvalidId_ReturnsNotFound()
        {
            var response = await _client.GetAsync("/api/event/999");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateEvent_ValidData_ReturnsCreated()
        {
            var newEvent = new
            {
                Name = "Integration Test Event",
                Description = "Integration test event description",
                StartDate = System.DateTime.Now.AddDays(10),
                EndDate = System.DateTime.Now.AddDays(11),
                Location = "Integration Test Location",
                TicketPrice = 123,
                TicketAmount = "50"
            };
            var response = await _client.PostAsJsonAsync("/api/event", newEvent);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task DeleteEvent_InvalidId_ReturnsNotFound()
        {
            var response = await _client.DeleteAsync("/api/event/999");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
