using MediatR;
using Portfolio.Shared.Models.Collectibles;

namespace Portfolio.UI.Requests.Queries
{
    public class GetPurchaseDetailByIdQuery : IRequest<PurchaseDetailModel>
    {
        public int Id { get; set; }

        public GetPurchaseDetailByIdQuery(int id)
        {
            Id = id;
        }
    }
}