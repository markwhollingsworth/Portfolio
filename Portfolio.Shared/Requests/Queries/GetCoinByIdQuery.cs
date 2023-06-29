using MediatR;
using Portfolio.Shared.Models;

namespace Portfolio.Shared.Requests.Queries
{
    public class GetCoinByIdQuery : IRequest<CoinModel>
    {
        public long Id { get; set; }

        public GetCoinByIdQuery(long id) => Id = id;
    }
}
