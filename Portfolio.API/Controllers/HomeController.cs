using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace Portfolio.API.Controllers
{
    [ApiController, Route("v1"), RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class HomeController : ControllerBase
    {
        [HttpGet, Route("")]
        public IActionResult Index()
        {
            return Ok("Portfolio API Home");
        }
    }
}
