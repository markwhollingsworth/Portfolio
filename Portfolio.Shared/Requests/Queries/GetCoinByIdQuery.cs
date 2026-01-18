using MediatR;
using Portfolio.UI.Models;

namespace Portfolio.UI.Requests.Queries
{
    public class GetCoinByIdQuery : IRequest<CoinModel>
    {
        public int Id { get; set; }

        public GetCoinByIdQuery(int id)
        {
            Id = id;
        }
    }
}
