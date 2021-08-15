using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebUI.Controllers
{
    /// <summary>
    /// View Controller that returns Home Views.
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        /// <summary>
        /// Creates a new instance of the Controller.
        /// </summary>
        /// <param name="logger">An implementation of <see cref="ILogger"/></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
