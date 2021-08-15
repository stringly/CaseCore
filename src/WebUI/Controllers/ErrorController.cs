using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CaseCore.WebUI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route("/error-local-developlemnt")]
        public IActionResult ErrorLocalDevelopment([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if(webHostEnvironment.EnvironmentName != "Development")
            {
                throw new InvalidOperationException("This method should not be invoked in non-development environments.");
            }
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            return Problem(
                detail: context.Error.StackTrace,
                title: context.Error.Message);
            
        }
        [Route("/error")]
        public IActionResult Error() => Problem();

    }
}
