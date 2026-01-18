using MediatR;
using Portfolio.UI.Interfaces;
using Portfolio.UI.Models;
using Portfolio.UI.Requests.Queries;

namespace Portfolio.UI.Handlers.Queries
{
    public class GetCoinByIdHandler : IRequestHandler<GetCoinByIdQuery, CoinModel?>
    {
        private readonly ICoinDataAccess _data;

        public GetCoinByIdHandler(ICoinDataAccess data) => _data = data;

        public async Task<CoinModel?> Handle(GetCoinByIdQuery request, CancellationToken cancellationToken)
        {
            return await _data.GetCoinByIdAsync(request.Id);
        }
    }
}
