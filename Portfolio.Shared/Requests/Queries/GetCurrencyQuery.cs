using MediatR;
using Portfolio.Shared.Models;

namespace Portfolio.Shared.Requests.Queries
{
    public class GetCurrencyQuery : IRequest<IEnumerable<CurrencyModel>?>
    {
        public record GetCurrency() : IRequest<IEnumerable<CurrencyModel>?>;
    }
}
