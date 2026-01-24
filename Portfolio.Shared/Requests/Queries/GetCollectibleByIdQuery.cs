using MediatR;
using Portfolio.Shared.Enums;
using Portfolio.Shared.Models;

namespace Portfolio.Shared.Requests.Queries
{
    public class GetCollectibleByIdQuery : IRequest<CollectibleModel>
    {
        public Guid Id { get; set; }

        public CollectibleType CollectibleType { get; set; }

        public GetCollectibleByIdQuery(Guid id, CollectibleType collectibleType)
        {
            Id = id;
            CollectibleType = collectibleType;
        }
    }
}
