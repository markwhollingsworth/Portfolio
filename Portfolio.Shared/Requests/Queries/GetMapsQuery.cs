using MediatR;
using Portfolio.Shared.Models;

namespace Portfolio.Shared.Requests.Queries
{
    public class GetMapsQuery : IRequest<IEnumerable<MapModel>?>
    {
        public record GetMaps() : IRequest<IEnumerable<MapModel>?>;
    }
}
