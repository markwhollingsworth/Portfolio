using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Portfolio.Shared.Repository;
using Portfolio.Shared.Requests.Queries;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.API.Controllers
{
    /// <summary>
    /// The Map controller provides endpoints for interacting with maps.
    /// </summary>
    [ApiController, 
     Route($"{Strings.V1Lowercase}/{Strings.MapsLowercase}"), 
     RequiredScope(RequiredScopesConfigurationKey = Strings.AzureAdScopes)]
    public class MapController : ControllerBase
    {
        /// <summary>
        /// Field for storing the injected mediator dependency.
        /// </summary>
        private ISender _mediator;

        /// <summary>
        /// Constructor used to inject our mediator dependency.
        /// </summary>
        /// <param name="mediator">The required mediator dependency used for the mediator behavioral design pattern.</param>
        public MapController(ISender mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets all maps.
        /// </summary>
        /// <returns>Returns a collection of maps.</returns>
        [HttpGet, Route(Strings.AllLowercase)]
        public async Task<IActionResult> GetMapsAsync()
        {
            return Ok(await _mediator.Send(new GetMapsQuery()));
        }

        /// <summary>
        /// Gets a map by id.
        /// </summary>
        /// <param name="id">The id of the map.</param>
        /// <returns>If a map is found for the corresponding Id, returns a map; else, returns null.</returns>
        [HttpGet, Route(Strings.IdOfTypeLong)]
        public async Task<IActionResult> GetMapByIdAsync([Range(1, long.MaxValue)] long id)
        {
            return Ok(await _mediator.Send(new GetMapByIdQuery(id)));
        }
    }
}