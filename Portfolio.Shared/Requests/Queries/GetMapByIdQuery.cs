using MediatR;
using Portfolio.Shared.Models;

namespace Portfolio.Shared.Requests.Queries
{
    public class GetMapByIdQuery : IRequest<MapModel>
    {
        public Guid Id { get; set; }

        public GetMapByIdQuery(Guid id) => Id = id;

        public record GetMapById(Guid Id) : IRequest<MapModel>;
    }
}
