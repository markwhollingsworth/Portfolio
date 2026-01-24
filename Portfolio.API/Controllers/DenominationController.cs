using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Identity.Web.Resource;
using Portfolio.Shared.Repository;
using Portfolio.Shared.Requests.Queries;

namespace Portfolio.API.Controllers
{
    /// <summary>
    /// Provides endpoints for interacting with denominations.
    /// </summary>
    [ApiController, 
     Route($"{Strings.V1Lowercase}/{Strings.DenominationLowercase}"), 
     RequiredScope(RequiredScopesConfigurationKey = Strings.AzureAdScopes)]
    public class DenominationController : ControllerBase
    {
        /// <summary>
        /// Field for storing the injected mediator dependency.
        /// </summary>
        private readonly ISender _mediator;

        /// <summary>
        /// Constructor used to inject our mediator dependency.
        /// </summary>
        /// <param name="mediator">The required mediator dependency used for the mediator behavioral design pattern.</param>
        public DenominationController(ISender mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets all the denominations from the database.
        /// </summary>
        /// <returns>Returns a list of denominations.</returns>
        [HttpGet, Route(Strings.EmptyString), Route(Strings.AllLowercase), OutputCache(Duration = 60)]
        public async Task<IActionResult> GetDenominations()
        {
            return Ok(await _mediator.Send(new GetDenominationsQuery()));
        }
    }
}
