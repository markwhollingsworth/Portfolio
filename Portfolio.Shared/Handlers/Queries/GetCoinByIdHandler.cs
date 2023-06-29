using MediatR;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Models;
using Portfolio.Shared.Requests.Queries;

namespace Portfolio.Shared.Handlers.Queries
{
    public class GetCoinByIdHandler : IRequestHandler<GetCoinByIdQuery, CoinModel?>
    {
        private readonly ICoinDataAccess _data;

        public GetCoinByIdHandler(ICoinDataAccess data) => _data = data;

        public async Task<CoinModel?> Handle(GetCoinByIdQuery request, CancellationToken cancellationToken)
        {
            return await _data.GetByIdAsync(request.Id);
        }
    }
}
