using MediatR;
using Portfolio.UI.Interfaces;
using Portfolio.UI.Models;
using Portfolio.UI.Requests.Queries;

namespace Portfolio.UI.Handlers.Queries
{
    public class GetMapByIdHandler : IRequestHandler<GetMapByIdQuery, MapModel?>
    {
        private readonly IMapDataAccess _data;

        public GetMapByIdHandler(IMapDataAccess data) => _data = data;

        public async Task<MapModel?> Handle(GetMapByIdQuery request, CancellationToken cancellationToken)
        {
            return await _data.GetMapByIdAsync(request.Id);
        }
    }
}
