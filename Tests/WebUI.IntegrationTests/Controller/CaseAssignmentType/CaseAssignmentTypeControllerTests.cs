using CaseCore.Application.AddressTypes.Queries.GetAddressTypeList;
using CaseCore.Application.CaseAssignmentTypes.Queries.GetCaseAssignmentTypeList;
using CaseCore.WebUI.IntegrationTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
