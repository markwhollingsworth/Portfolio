using MediatR;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Models;
using Portfolio.Shared.Requests.Queries;

namespace Portfolio.Shared.Handlers.Queries
{
    public class GetMintsHandler : IRequestHandler<GetMintsQuery, IEnumerable<MintModel>?>
    {
        private readonly IMintDataAccess _data;

        public GetMintsHandler(IMintDataAccess data) => _data = data;

        public async Task<IEnumerable<MintModel>?> Handle(GetMintsQuery request, CancellationToken cancellationToken)
        {
            return await _data.GetMintsAsync();
        }
    }
}
