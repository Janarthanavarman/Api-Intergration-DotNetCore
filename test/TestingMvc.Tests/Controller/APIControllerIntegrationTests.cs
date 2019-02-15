using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MVCAdoDemo.Models;    
using Xunit;
using MvcAdoDemo;
using System;
using System.Net;
using MvcAdoDemo.Models;
using System.Text;

namespace Web.Api.IntegrationTests.Controllers
{
    //https://dotnetcorecentral.com/blog/asp-net-core-web-api-integration-testing-with-xunit/
    public class PlayersControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;       
        AppIMDBContext cont;

        public PlayersControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            this._client = factory.CreateClient();
            //this.cont =cont;         
            _client.BaseAddress = new Uri("https://localhost:5001");            
        }

        [Fact]
        public async Task CanGetAll()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/api/StudentAPI/DashBoard");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();
            //httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var players = JsonConvert.DeserializeObject<IEnumerable<Student>>(stringResponse);


            Assert.Contains(players, p => p.Name=="AAAAA");
            Assert.Contains(players, p => p.Name == "BBBBB");            
        }

        [Fact]
        public async Task CanCreate()
        {
            // The endpoint or route of the controller action.
            
            //  var response = await client.PostAsync("/api/employee"
            //     , new StringContent(
            //     JsonConvert.SerializeObject(new Employee()
            // {
            //     Address = "Test",
            //     FirstName = "John",
            //     LastName = "Mak",
            //     CellPhone = "111-222-3333",
            //     HomePhone = "222-333-4444"
            // }), 
            // Encoding.UTF8, 
            // "application/json"));
            var json = JsonConvert.SerializeObject(new Student()
            {
                Name = "Test2",
                Department = "D",
                Gender = "F",
                City = "D"
            });
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var httpResponse = await _client.PutAsync("/api/StudentAPI/create",stringContent);
            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();
           Assert.Equal(HttpStatusCode.Created,httpResponse.StatusCode);
        }


        [Fact]
        public async Task CanGetByIdWrong()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/api/StudentAPI/Edit?id=16");
           // httpResponse.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NotFound, httpResponse.StatusCode);
        }

         [Fact]
        public async Task CanGetById()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/api/StudentAPI/Edit?id=2");
            httpResponse.EnsureSuccessStatusCode();
            Assert.NotEqual(HttpStatusCode.NotFound, httpResponse.StatusCode);

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var sss = JsonConvert.DeserializeObject<Student>(stringResponse);
            Assert.Contains("BBBBB", sss.Name );  
        }

         [Fact]
        public async Task CanDeleteById()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.DeleteAsync("/api/StudentAPI/Delete?id=3");
            httpResponse.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Accepted, httpResponse.StatusCode);

            
        }

    }    
}