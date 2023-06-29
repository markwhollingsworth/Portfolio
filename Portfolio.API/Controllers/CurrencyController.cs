using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Portfolio.Shared.Requests.Queries;
using Portfolio.Shared.Repository;
using Portfolio.Shared.Requests;
using System.ComponentModel.DataAnnotations;
using Portfolio.Shared.Requests.Commands;

namespace Portfolio.API.Controllers
{
    /// <summary>
    /// Provides endpoints for interacting with currency.
    /// </summary>
    [ApiController,
     Route($"{Strings.V1Lowercase}/{Strings.CurrencyLowercase}"),
     RequiredScope(RequiredScopesConfigurationKey = Strings.AzureAdScopes)]
    public class CurrencyController : ControllerBase
    {
        /// <summary>
        /// Field for storing the injected mediator dependency.
        /// </summary>
        private readonly ISender _mediator;

        /// <summary>
        /// Constructor used to inject our mediator dependency.
        /// </summary>
        /// <param name="mediator">The required mediator dependency used for the mediator behavioral design pattern.</param>
        public CurrencyController(ISender mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets all currency.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route(Strings.EmptyString)]
        public async Task<IActionResult> GetCurrencyAsync()
        {
            return Ok(await _mediator.Send(new GetCurrencyQuery()));
        }

        /// <summary>
        /// Gets currency by Id.
        /// </summary>
        /// <param name="id">The Id of the currency.</param>
        /// <returns>Returns the details about the currency.</returns>
        [HttpGet, Route(Strings.IdOfTypeLong)]
        public async Task<IActionResult> GetCurrencyByIdAsync([Range(1, long.MaxValue)] long id)
        {
            return Ok(await _mediator.Send(new GetCurrencyByIdQuery(id)));
        }

        /// <summary>
        /// Saves currency to the database.
        /// </summary>
        /// <param name="request">The request object containing details about the currency to edit.</param>
        /// <returns>Returns the number of rows affected.</returns>
        [HttpPost, Route(Strings.AddLowercase)]
        public async Task<IActionResult> AddCurrencyAsync([Required(ErrorMessage = Strings.RequestRequiredMessage)] AddCurrencyRequest request)
        {
            return Ok(await _mediator.Send(new AddCurrencyCommand(request)));
        }

        /// <summary>
        /// Updates existing currency.
        /// </summary>
        /// <param name="request">The request containing details about the changes to the curency.</param>
        /// <returns>Returns the number of rows affected.</returns>
        [HttpPut, Route(Strings.UpdateLowercase)]
        public async Task<IActionResult> UpdateCurrencyAsync([Required(ErrorMessage = Strings.RequestRequiredMessage)] UpdateCurrencyRequest request)
        {
            return Ok(await _mediator.Send(new UpdateCurrencyCommand(request)));
        }
    }
}