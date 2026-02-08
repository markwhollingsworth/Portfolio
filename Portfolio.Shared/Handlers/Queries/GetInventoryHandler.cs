using MediatR;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Models;
using Portfolio.Shared.Requests.Queries;

namespace Portfolio.Shared.Handlers.Queries
{
    public class GetInventoryHandler : IRequestHandler<GetInventoryQuery, PaginatedResult<InventoryModel>>
    {
        private readonly IInventoryDataAccess _data;

        public GetInventoryHandler(IInventoryDataAccess data) => _data = data;

        public async Task<PaginatedResult<InventoryModel>> Handle(GetInventoryQuery request, CancellationToken cancellationToken)
        {
            return await _data.GetInventoryAsync(request);
        }
    }
}
