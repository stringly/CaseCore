using CaseCore.Application.AddressTypes.Commands.UpsertAddressType;
using CaseCore.Application.AddressTypes.Queries.GetAddressTypeDetail;
using CaseCore.Application.AddressTypes.Queries.GetAddressTypeList;
using CaseCore.WebUI.IntegrationTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.WebUI.IntegrationTests.Controller.AddressType
{
    public class AddressTypeControllerTests : ControllerTestBase
    {        
        public AddressTypeControllerTests()
        {            
        }
        [Fact]
        public async Task GetAll_AddressTypes_Returns_SuccessResult()
        {
            // Arrange            
            var response = await _client.GetAsync("api/AddressType/GetAll");

            // Assert
            response.EnsureSuccessStatusCode();
            var vm = await Utilities.GetResponseContent<AddressTypeListVm>(response);

            Assert.IsType<AddressTypeListVm>(vm);
            Assert.NotEmpty(vm.AddressTypes);
        }
        [Fact]
        public async Task Given_Valid_Id_Returns_AddressTypeViewModel()
        {
            // Arrange
            var id = 1;

            // Act
            var response = await _client.GetAsync($"api/AddressType/Get/{id}");
            
            // Assert
            response.EnsureSuccessStatusCode();
            var addressType = await Utilities.GetResponseContent<AddressTypeDetailVm>(response);
            Assert.Equal(id, addressType.AddressType.Id);
        }
        [Fact]
        public async Task Given_Invalid_Id_Returns_NotFoundStatusCode()
        {
            // Arrange
            var invalidId = 100;

            // Act
            var response = await _client.GetAsync($"api/AddressType/Get/{invalidId}");
            var statusCode = HttpStatusCode.NotFound;
            var responseCode = response.StatusCode;
            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task Given_Valid_Values_Upsert_Returns_SuccessResult()
        {
            // Arrange
            var command = new UpsertAddressTypeCommand
            {
                Name = "New Address Type",
                Abbreviation = "NEW"
            };
            var content = Utilities.GetRequestContent(command);

            // Act
            var response = await _client.PostAsync("api/AddressType/Upsert", content);

            // Assert
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task Given_Taken_Name_Upsert_Returns_BadRequest_With_ValidationErrors()
        {
            // Arrange
            var command = new UpsertAddressTypeCommand
            {
                Name = "Location of Incident",
                Abbreviation = "XXXX"
            };
            var content = Utilities.GetRequestContent(command);

            // Act
            var response = await _client.PostAsync("api/AddressType/Upsert", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Given_Valid_Id_Delete_Returns_SuccessResult()
        {
            // Arrange
            var validId = 1;

            // Act
            var response = await _client.DeleteAsync($"api/AddressType/Delete/{validId}");

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
        [Fact]
        public async Task Given_Invalid_Id_Delete_Returns_NotFoundStatusCode()
        {
            // Arrange
            var invalidId = 100;

            // Act
            var response = await _client.DeleteAsync($"api/AddressType/Delete/{invalidId}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
