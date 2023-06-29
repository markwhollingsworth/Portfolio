using MediatR;
using Portfolio.Shared.Models;

namespace Portfolio.Shared.Requests.Queries
{
    public class GetCurrencyByIdQuery : IRequest<CurrencyModel?>
    {
        public long Id { get; set; }

        public GetCurrencyByIdQuery(long id) => Id = id;
    }
}
