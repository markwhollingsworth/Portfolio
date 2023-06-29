using MediatR;
using Portfolio.Shared.Models;

namespace Portfolio.Shared.Requests.Queries
{
    public class GetInventoryQuery : IRequest<IEnumerable<InventoryModel>?>
    {
        public record GetInventory() : IRequest<IEnumerable<InventoryModel>?>;
    }
}