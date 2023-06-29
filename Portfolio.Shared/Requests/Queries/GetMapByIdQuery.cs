using MediatR;
using Portfolio.Shared.Models;

namespace Portfolio.Shared.Requests.Queries
{
    public class GetMapByIdQuery : IRequest<MapModel>
    {
        public long Id { get; set; }

        public GetMapByIdQuery(long id) => Id = id;

        public record GetMapById(long Id) : IRequest<MapModel>;
    }
}
