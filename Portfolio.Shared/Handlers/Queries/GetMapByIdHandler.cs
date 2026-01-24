using MediatR;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Models;
using Portfolio.Shared.Requests.Queries;

namespace Portfolio.Shared.Handlers.Queries
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
