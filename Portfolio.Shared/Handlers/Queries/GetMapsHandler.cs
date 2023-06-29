using MediatR;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Models;
using Portfolio.Shared.Requests.Queries;

namespace Portfolio.Shared.Handlers.Queries
{
    public class GetMapsHandler : IRequestHandler<GetMapsQuery, IEnumerable<MapModel>?>
    {
        private readonly IMapDataAccess _data;

        public GetMapsHandler(IMapDataAccess data) => _data = data;

        public async Task<IEnumerable<MapModel>?> Handle(GetMapsQuery request, CancellationToken cancellationToken)
        {
            return await _data.GetMapsAsync();
        }
    }
}
