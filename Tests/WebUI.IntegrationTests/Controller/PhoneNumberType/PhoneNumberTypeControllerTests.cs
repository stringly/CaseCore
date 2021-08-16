using CaseCore.Application.PhoneNumberTypes.Commands.UpsertPhoneNumberType;
using CaseCore.Application.PhoneNumberTypes.Queries.GetPhoneNumberTypeDetail;
using CaseCore.Application.PhoneNumberTypes.Queries.GetPhoneNumberTypeList;
using CaseCore.WebUI.IntegrationTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CaseCore.WebUI.IntegrationTests.Controller.PhoneNumberType
{
    public class PhoneNumberTypeControllerTests : ControllerTestBase
    {
        public PhoneNumberTypeControllerTests()
        {
        }
        [Fact]
        public async Task GetAll_PhoneNumberTypes_Returns_SuccessResult()
        {
            // Arrange            
            var response = await _client.GetAsync("api/PhoneNumberType/GetAll");

            // Assert
            response.EnsureSuccessStatusCode();
            var vm = await Utilities.GetResponseContent<PhoneNumberTypeListVm>(response);

            Assert.IsType<PhoneNumberTypeListVm>(vm);
            Assert.NotEmpty(vm.PhoneNumberTypes);
        }
        [Fact]
        public async Task Given_Valid_Id_Returns_PhoneNumberTypeViewModel()
        {
            // Arrange
            var id = 1;

            // Act
            var response = await _client.GetAsync($"api/PhoneNumberType/Get?id={id}");

            // Assert
            response.EnsureSuccessStatusCode();
            var phoneNumberType = await Utilities.GetResponseContent<PhoneNumberTypeDetailVm>(response);
            Assert.Equal(id, phoneNumberType.PhoneNumberType.Id);
        }
        [Fact]
        public async Task Given_Invalid_Id_Returns_NotFoundStatusCode()
        {
            // Arrange
            var invalidId = 100;

            // Act
            var response = await _client.GetAsync($"api/PhoneNumberType/Get?id={invalidId}");
            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task Given_Valid_Values_Upsert_Returns_SuccessResult()
        {
            // Arrange
            var command = new UpsertPhoneNumberTypeCommand
            {
                Name = "New Phone Number Type",
                Abbreviation = "NEW"
            };
            var content = Utilities.GetRequestContent(command);

            // Act
            var response = await _client.PostAsync("api/PhoneNumberType/Upsert", content);

            // Assert
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task Given_Taken_Name_Upsert_Returns_BadRequest_With_ValidationErrors()
        {
            // Arrange
            var command = new UpsertPhoneNumberTypeCommand
            {
                Name = "Home",
                Abbreviation = "XXXX"
            };
            var content = Utilities.GetRequestContent(command);

            // Act
            var response = await _client.PostAsync("api/PhoneNumberType/Upsert", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task Given_Valid_Id_Delete_Returns_SuccessResult()
        {
            // Arrange
            var validId = 1;

            // Act
            var response = await _client.DeleteAsync($"api/PhoneNumberType/Delete?id={validId}");

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
        [Fact]
        public async Task Given_Invalid_Id_Delete_Returns_NotFoundStatusCode()
        {
            // Arrange
            var invalidId = 100;

            // Act
            var response = await _client.DeleteAsync($"api/PhoneNumberType/Delete?id={invalidId}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
