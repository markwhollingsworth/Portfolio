using MediatR;
using Portfolio.UI.Interfaces;
using Portfolio.UI.Models;
using Portfolio.UI.Requests.Queries;

namespace Portfolio.UI.Handlers.Queries
{
    public class GetMintsHandler : IRequestHandler<GetMintsQuery, IEnumerable<MintModel>?>
    {
        private readonly ICoinDataAccess _data;

        public GetMintsHandler(ICoinDataAccess data) => _data = data;

        public async Task<IEnumerable<MintModel>?> Handle(GetMintsQuery request, CancellationToken cancellationToken)
        {
            return await _data.GetMintsAsync();
        }
    }
}
