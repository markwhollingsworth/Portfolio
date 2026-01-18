using MediatR;
using Portfolio.UI.Interfaces;
using Portfolio.UI.Models;
using Portfolio.UI.Requests.Queries;

namespace Portfolio.UI.Handlers.Queries
{
    public class GetCoinsHandler : IRequestHandler<GetCoinsQuery, IEnumerable<InventoryModel>?>
    {
        private readonly ICoinDataAccess _data;

        public GetCoinsHandler(ICoinDataAccess data) => _data = data;

        public async Task<IEnumerable<InventoryModel>?> Handle(GetCoinsQuery request, CancellationToken cancellationToken)
        {
            return await _data.GetCoinsAsync();
        }
    }
}
