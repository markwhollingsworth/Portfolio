using MediatR;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Models;
using Portfolio.Shared.Requests.Queries;

namespace Portfolio.Shared.Handlers.Queries
{
    public class GetCollectibleByIdHandler : IRequestHandler<GetCollectibleByIdQuery, CollectibleModel?>
    {
        private readonly ICollectibleDataAccess _data;

        public GetCollectibleByIdHandler(ICollectibleDataAccess data) => _data = data;

        public async Task<CollectibleModel?> Handle(GetCollectibleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _data.GetByIdAsync(request.Id, request.CollectibleType);
        }
    }
}
