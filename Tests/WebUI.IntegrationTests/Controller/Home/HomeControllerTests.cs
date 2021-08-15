using CaseCore.WebUI.IntegrationTests.Common;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.WebUI.IntegrationTests.Controller.Home
{
    public class HomeControllerTests : ControllerTestBase
    {
        public HomeControllerTests()
        {
        }
        [Theory]
        [InlineData("/")]
        [InlineData("Home/Index")]
        public async Task Get_Endpoints_Returns_Success_And_Correct_ContentType(string url)
        {
            // Arrange/Act
            var response = await _client.GetAsync(url);            

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
        [Fact]
        public async Task Get_Swagger_Returns_SuccessResult()
        {
            // Arrange
            var response = await _client.GetAsync("swagger/index.html");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
