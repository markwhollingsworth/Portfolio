using MediatR;
using Portfolio.UI.Models;

namespace Portfolio.UI.Requests.Queries
{
    public class GetCoinsQuery : IRequest<IEnumerable<InventoryModel>?>
    {
        public record GetCoins() : IRequest<IEnumerable<InventoryModel>?>;
    }
}