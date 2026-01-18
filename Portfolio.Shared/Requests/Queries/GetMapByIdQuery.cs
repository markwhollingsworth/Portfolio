using MediatR;
using Portfolio.UI.Models;

namespace Portfolio.UI.Requests.Queries
{
    public class GetMapByIdQuery : IRequest<MapModel>
    {
        public int Id { get; set; }

        public GetMapByIdQuery(int id) => Id = id;

        public record GetMapById(Guid Id) : IRequest<MapModel>;
    }
}
