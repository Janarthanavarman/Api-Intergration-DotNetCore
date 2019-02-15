using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MVCAdoDemo.Models;    
using Xunit;
using MvcAdoDemo;
using System;

namespace Web.Api.IntegrationTests.Controllers
{
    public class PlayersControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public PlayersControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            _client.BaseAddress = new Uri("https://localhost:5001");
        }

        [Fact]
        public async Task CanGetPlayers()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/api/StudentAPI/DashBoard");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var players = JsonConvert.DeserializeObject<IEnumerable<Student>>(stringResponse);
            Assert.Contains(players, p => p.Name=="Aaad");
            Assert.Contains(players, p => p.Name == "Aa");
        }


        [Fact]
        public async Task CanGetPlayerById()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/api/StudentAPI/Edit?id=16");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var player = JsonConvert.DeserializeObject<Student>(stringResponse);
            Assert.Equal(16,player.ID);
            Assert.Equal("Aa", player.Name);
        }
    }
}