using MediatR;
using Portfolio.UI.Interfaces;
using Portfolio.UI.Models;
using Portfolio.UI.Requests.Queries;

namespace Portfolio.UI.Handlers.Queries
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
