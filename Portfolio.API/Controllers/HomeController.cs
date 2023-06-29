using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Portfolio.Shared.Repository;

namespace Portfolio.API.Controllers
{
    /// <summary>
    /// This controller provides a simple way to tell if the API is up.
    /// </summary>
    [ApiController, 
     Route(Strings.V1Lowercase), 
     RequiredScope(RequiredScopesConfigurationKey = Strings.AzureAdScopes)]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// The default endpoint for the API used to determine whether or not the API is running in Azure.
        /// </summary>
        /// <returns>Returns a string "Portfolio API Home".</returns>
        [HttpGet, Route(Strings.EmptyString)]
        public IActionResult Index()
        {
            return Ok("Portfolio API Home");
        }
    }
}
