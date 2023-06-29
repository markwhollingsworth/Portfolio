using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Portfolio.Shared.Repository;
using Portfolio.Shared.Requests.Queries;

namespace Portfolio.API.Controllers
{
    /// <summary>
    /// The Inventory controller provides endpoints for interacting with maps.
    /// </summary>
    [ApiController, 
     Route($"{Strings.V1Lowercase}/{Strings.InventoryLowercase}"), 
     RequiredScope(RequiredScopesConfigurationKey = Strings.AzureAdScopes)]
    public class InventoryController : ControllerBase
    {
        /// <summary>
        /// Field for storing the injected mediator dependency.
        /// </summary>
        private readonly ISender _mediator;

        /// <summary>
        /// Constructor used to inject our mediator dependency.
        /// </summary>
        /// <param name="mediator">The required mediator dependency used for the mediator behavioral design pattern.</param>
        public InventoryController(ISender mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets all coin inventory.
        /// </summary>
        /// <returns>Returns a collection of coin inventory.</returns>
        [HttpGet, Route(Strings.EmptyString)]
        public async Task<IActionResult> GetInventoryAsync()
        {
            return Ok(await _mediator.Send(new GetInventoryQuery()));
        }
    }
}