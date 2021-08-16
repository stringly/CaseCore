using CaseCore.Application.CaseStatusTypes.Commands.UpsertCaseStatusType;
using CaseCore.Application.CaseStatusTypes.Queries.GetCaseStatusTypeDetail;
using CaseCore.Application.CaseStatusTypes.Queries.GetCaseStatusTypeList;
using CaseCore.WebUI.IntegrationTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.WebUI.IntegrationTests.Controller.CaseStatusType
{
    public class CaseStatusTypeControllerTests : ControllerTestBase
    {
        [Fact]
        public async Task GetAll_CaseStatusTypes_Returns_SuccessResult()
        {
            // Arrange
            var response = await _client.GetAsync("api/CaseStatusType/GetAll");

            // Assert
            response.EnsureSuccessStatusCode();
            var vm = await Utilities.GetResponseContent<CaseStatusTypeListVm>(response);

            Assert.IsType<CaseStatusTypeListVm>(vm);
            Assert.NotEmpty(vm.CaseStatusTypes);
        }
        [Fact]
        public async Task Given_Valid_Id_Returns_CaseStatusTypeViewModel()
        {
            // Arrange
            var id = 1;

            // Act
            var response = await _client.GetAsync($"api/CaseStatusType/Get?id={id}");

            // Assert
            response.EnsureSuccessStatusCode();
            var caseStatusType = await Utilities.GetResponseContent<CaseStatusTypeDetailVm>(response);
            Assert.Equal(id, caseStatusType.CaseStatusType.Id);
        }
        [Fact]
        public async Task Given_Invalid_Id_Returns_NotFoundStatusCode()
        {
            // Arrange
            var invalidId = 100;

            // Act
            var response = await _client.GetAsync($"api/CaseStatusType/Get?id-{invalidId}");
            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task Given_Valid_Values_Upsert_Returns_SuccessResult()
        {
            // Arrange
            var command = new UpsertCaseStatusTypeCommand
            {
                Name = "New Case Status Type"
            };
            var content = Utilities.GetRequestContent(command);

            // Act
            var response = await _client.PostAsync("api/CaseStatusType/Upsert", content);

            // Assert
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task Given_Taken_Name_Upsert_Returns_BadRequest_With_ValidationErrors()
        {
            // Arrange
            var command = new UpsertCaseStatusTypeCommand
            {
                Name = "Open"
            };
            var content = Utilities.GetRequestContent(command);

            // Act
            var response = await _client.PostAsync("api/CaseStatusType/Upsert", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task Given_Valid_Id_Delete_Returns_SuccessResult()
        {
            // Arrange
            var validId = 1;

            // Act
            var response = await _client.DeleteAsync($"api/CaseStatusType/Delete?id={validId}");

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
        [Fact]
        public async Task Given_Invalid_Id_Delete_Returns_NotFoundStatusCode()
        {
            // Arrange
            var invalidId = 100;

            // Act
            var response = await _client.DeleteAsync($"api/CaseStatusType/Delete?id={invalidId}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
