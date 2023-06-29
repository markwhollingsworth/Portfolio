using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Portfolio.Shared.Requests.Queries;
using Portfolio.Shared.Repository;
using Microsoft.AspNetCore.OutputCaching;

namespace Portfolio.API.Controllers
{
    /// <summary>
    /// The Mint controller provides endpoints for interacting with mints.
    /// </summary>
    [ApiController, 
     Route($"{Strings.V1Lowercase}/{Strings.MintLowercase}"), 
     RequiredScope(RequiredScopesConfigurationKey = Strings.AzureAdScopes)]
    public class MintController : ControllerBase
    {
        /// <summary>
        /// Field for storing the injected mediator dependency.
        /// </summary>
        private readonly ISender _mediator;

        /// <summary>
        /// Constructor used to inject our mediator dependency.
        /// </summary>
        /// <param name="mediator">The required mediator dependency used for the mediator behavioral design pattern.</param>
        public MintController(ISender mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets all mints.
        /// </summary>
        /// <returns>Returns a collection of mints.</returns>
        [HttpGet, Route(Strings.MintsLowercase), OutputCache(Duration = 60)]
        public async Task<IActionResult> GetMintsAsync()
        {
            return Ok(await _mediator.Send(new GetMintsQuery()));
        }
    }
}
