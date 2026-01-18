using MediatR;
using Portfolio.UI.Models;

namespace Portfolio.UI.Requests.Queries
{
    public class GetMapsQuery : IRequest<IEnumerable<MapModel>?>
    {
        public record GetMaps() : IRequest<IEnumerable<MapModel>?>;
    }
}
