using CaseCore.Application.Common.Interfaces;

namespace CaseCore.Application.UnitTests.Common
{
    public class CurrentUserServiceTesting : ICurrentUserService
    {
        public CurrentUserServiceTesting()
        {
            UserId = "jcsmith1";
            IsAuthenticated = true;
            // TODO: why can't I access UserId from ClaimsLoader?
        }
        public CurrentUserServiceTesting(string LDAPName, bool isAuthenticated)
        {
            UserId = LDAPName;
            IsAuthenticated = isAuthenticated;
        }
        public string UserId { get; private set; }

        public bool IsAuthenticated { get; private set; }
    }
}
