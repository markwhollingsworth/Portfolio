using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Portfolio.Shared.Repository;
using Portfolio.Shared.Requests.Collectibles.Coin;
using Portfolio.Shared.Requests.Commands;
using Portfolio.Shared.Requests.Queries;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.API.Controllers
{
    /// <summary>
    /// Provides endpoints for interacting with coins.
    /// </summary>
    [ApiController,
     Route($"{Strings.V1Lowercase}/{Strings.CoinLowercase}"),
     RequiredScope(RequiredScopesConfigurationKey = Strings.AzureAdScopes)]
    public class CoinController : ControllerBase
    {
        /// <summary>
        /// Field for storing the injected mediator dependency.
        /// </summary>
        private readonly ISender _mediator;

        /// <summary>
        /// Constructor used to inject our mediator dependency.
        /// </summary>
        /// <param name="mediator">The required mediator dependency used for the mediator behavioral design pattern.</param>
        public CoinController(ISender mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets a specific coin based off an id.
        /// </summary>
        /// <param name="id">The id of the coin.</param>
        /// <returns>Returns the details of a coin, if found.</returns>
        [HttpGet, Route(Strings.IdOfTypeLong)]
        public async Task<IActionResult> GetByIdAsync([Range(1, long.MaxValue)] long id)
        {
            return Ok(await _mediator.Send(new GetCoinByIdQuery(id)));
        }

        /// <summary>
        /// Adds a new coin.
        /// </summary>
        /// <param name="request">The request containing details about the new coin.</param>
        /// <returns>Returns an integer value indicating the number of rows affected."/></returns>
        [HttpPost, Route(Strings.AddLowercase)]
        public async Task<IActionResult> AddCoinAsync([Required(ErrorMessage = Strings.RequestRequiredMessage)] AddCoinRequest request)
        {
            return Ok(await _mediator.Send(new AddCoinCommand(request)));
        }

        /// <summary>
        /// Updates an existing coin.
        /// </summary>
        /// <param name="request">The request containing details about the coin to update.</param>
        /// <returns>Returns an integer value indicating the number of rows affected.</returns>
        [HttpPut, Route(Strings.UpdateLowercase)]
        public async Task<IActionResult> UpdateCoin([Required(ErrorMessage = Strings.RequestRequiredMessage)] UpdateCoinRequest request)
        {
            return Ok(await _mediator.Send(new UpdateCoinCommand(request)));
        }
    }
}