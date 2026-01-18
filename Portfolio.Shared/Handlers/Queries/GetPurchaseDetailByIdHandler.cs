using MediatR;
using Portfolio.Shared.Models.Collectibles;
using Portfolio.UI.Interfaces;
using Portfolio.UI.Requests.Queries;

namespace Portfolio.UI.Handlers.Queries
{
    public class GetPurchaseDetailByIdHandler : IRequestHandler<GetPurchaseDetailByIdQuery, PurchaseDetailModel?>
    {
        private readonly ICoinDataAccess _data;

        public GetPurchaseDetailByIdHandler(ICoinDataAccess data) => _data = data;

        public async Task<PurchaseDetailModel?> Handle(GetPurchaseDetailByIdQuery request, CancellationToken cancellationToken)
        {
            return await _data.GetPurchaseDetailByIdAsync(request.Id);
        }
    }
}
