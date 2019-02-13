using System;
using Xunit;

namespace TestingMvc.Tests
{
    public class UnitTest1:IClassFixture<WebApplicationTestFixture<Startup>>
    {

         public UnitTest1(WebApplicationTestFixture<Startup> fixture)
        {            
            Client = fixture.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task GetHomePage()
        {
            // Arrange & Act
            var response = await Client.Get("/");

            // Assert or Then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
