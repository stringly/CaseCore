using CaseCore.Application.PersonTypes.Commands.UpsertPersonType;
using CaseCore.Application.PersonTypes.Queries.GetPersonTypeDetail;
using CaseCore.Application.PersonTypes.Queries.GetPersonTypeList;
using CaseCore.WebUI.IntegrationTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.WebUI.IntegrationTests.Controller.Person
{
    public class PersonTypeControllerTests : ControllerTestBase
    {
        public PersonTypeControllerTests()
        {
        }
        [Fact]
        public async Task GetAll_PersonTypes_Returns_SuccessResult()
        {
            // Arrange            
            var response = await _client.GetAsync("api/PersonType/GetAll");

            // Assert
            response.EnsureSuccessStatusCode();
            var vm = await Utilities.GetResponseContent<PersonTypeListVm>(response);

            Assert.IsType<PersonTypeListVm>(vm);
            Assert.NotEmpty(vm.PersonTypes);
        }
        [Fact]
        public async Task Given_Valid_Id_Returns_PersonTypeViewModel()
        {
            // Arrange
            var id = 1;

            // Act
            var response = await _client.GetAsync($"api/PersonType/Get?id={id}");

            // Assert
            response.EnsureSuccessStatusCode();
            var addressType = await Utilities.GetResponseContent<PersonTypeDetailVm>(response);
            Assert.Equal(id, addressType.PersonType.Id);
        }
        [Fact]
        public async Task Given_Invalid_Id_Returns_NotFoundStatusCode()
        {
            // Arrange
            var invalidId = 100;

            // Act
            var response = await _client.GetAsync($"api/PersonType/Get?id={invalidId}");
            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task Given_Valid_Values_Upsert_Returns_SuccessResult()
        {
            // Arrange
            var command = new UpsertPersonTypeCommand
            {
                Name = "New Person Type",
                Abbreviation = "NEW"
            };
            var content = Utilities.GetRequestContent(command);

            // Act
            var response = await _client.PostAsync("api/PersonType/Upsert", content);

            // Assert
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task Given_Taken_Name_Upsert_Returns_BadRequest_With_ValidationErrors()
        {
            // Arrange
            var command = new UpsertPersonTypeCommand
            {
                Name = "Victim",
                Abbreviation = "XXXX"
            };
            var content = Utilities.GetRequestContent(command);

            // Act
            var response = await _client.PostAsync("api/PersonType/Upsert", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task Given_Valid_Id_Delete_Returns_SuccessResult()
        {
            // Arrange
            var validId = 1;

            // Act
            var response = await _client.DeleteAsync($"api/PersonType/Delete?id={validId}");

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
        [Fact]
        public async Task Given_Invalid_Id_Delete_Returns_NotFoundStatusCode()
        {
            // Arrange
            var invalidId = 100;

            // Act
            var response = await _client.DeleteAsync($"api/PersonType/Delete?id={invalidId}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
