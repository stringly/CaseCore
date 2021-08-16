using CaseCore.Application.CaseAssignmentTypes.Commands.UpsertCaseAssignmentType;
using CaseCore.Application.CaseAssignmentTypes.Queries.GetCaseAssignmentTypeDetail;
using CaseCore.Application.CaseAssignmentTypes.Queries.GetCaseAssignmentTypeList;
using CaseCore.WebUI.IntegrationTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.WebUI.IntegrationTests.Controller.CaseAssignmentType
{
    public class CaseAssignmentTypeControllerTests : ControllerTestBase
    {
        [Fact]
        public async Task GetAll_CaseAssignmentTypes_Returns_SuccessResult()
        {
            // Arrange
            var response = await _client.GetAsync("api/CaseAssignmentType/GetAll");

            // Assert
            response.EnsureSuccessStatusCode();
            var vm = await Utilities.GetResponseContent<CaseAssignmentTypeListVm>(response);

            Assert.IsType<CaseAssignmentTypeListVm>(vm);
            Assert.NotEmpty(vm.CaseAssignmentTypes);
        }
        [Fact]
        public async Task Given_Valid_Id_Returns_CaseAssignmentTypeViewModel()
        {
            // Arrange
            var id = 1;

            // Act
            var response = await _client.GetAsync($"api/CaseAssignmentType/Get?id={id}");

            // Assert
            response.EnsureSuccessStatusCode();
            var caseAssignmentType = await Utilities.GetResponseContent<CaseAssignmentTypeDetailVm>(response);
            Assert.Equal(id, caseAssignmentType.CaseAssignmentType.Id);
        }
        [Fact]
        public async Task Given_Invalid_Id_Returns_NotFoundStatusCode()
        {
            // Arrange
            var invalidId = 100;

            // Act
            var response = await _client.GetAsync($"api/CaseAssignmentType/Get?id={invalidId}");
            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task Given_Valid_Values_Upsert_Returns_SuccessResult()
        {
            // Arrange
            var command = new UpsertCaseAssignmentTypeCommand
            {
                Name = "New Case Assignment Type"
            };
            var content = Utilities.GetRequestContent(command);

            // Act
            var response = await _client.PostAsync("api/CaseAssignmentType/Upsert", content);

            // Assert
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task Given_Taken_Name_Upsert_Returns_BadRequest_With_ValidationErrors()
        {
            // Arrange
            var command = new UpsertCaseAssignmentTypeCommand
            {
                Name = "Initial"                
            };
            var content = Utilities.GetRequestContent(command);

            // Act
            var response = await _client.PostAsync("api/CaseAssignmentType/Upsert", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task Given_Valid_Id_Delete_Returns_SuccessResult()
        {
            // Arrange
            var validId = 1;

            // Act
            var response = await _client.DeleteAsync($"api/CaseAssignmentType/Delete?id={validId}");

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
        [Fact]
        public async Task Given_Invalid_Id_Delete_Returns_NotFoundStatusCode()
        {
            // Arrange
            var invalidId = 100;

            // Act
            var response = await _client.DeleteAsync($"api/CaseAssignmentType/Delete?id={invalidId}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
