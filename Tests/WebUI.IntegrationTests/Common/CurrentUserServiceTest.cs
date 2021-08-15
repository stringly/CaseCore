using CaseCore.Application.Common.Interfaces;

namespace CaseCore.WebUI.IntegrationTests.Common
{
    public class CurrentUserServiceTest : ICurrentUserService
    {
        public string UserId => "user123";

        public bool IsAuthenticated => true;
    }
}