using CaseCore.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CaseCore.WebUI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            string userName = httpContextAccessor.HttpContext?.User?.Identity?.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                userName = userName.Split('\\')[1];
                UserId = userName;
            }
            IsAuthenticated = UserId != null;
        }
        public string UserId { get; }
        public bool IsAuthenticated { get; }
    }
}
