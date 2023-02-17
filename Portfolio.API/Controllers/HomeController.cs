using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace Portfolio.API.Controllers
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes"), ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet, Route("")]
        public IActionResult Index()
        {
            return Ok("Portfolio API Home");
        }
    }
}
