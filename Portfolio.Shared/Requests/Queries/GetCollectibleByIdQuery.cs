using MediatR;
using Portfolio.Shared.Enums;
using Portfolio.Shared.Models;

namespace Portfolio.Shared.Requests.Queries
{
    public class GetCollectibleByIdQuery : IRequest<CollectibleModel>
    {
        public int Id { get; set; }

        public CollectibleType CollectibleType { get; set; }

        public GetCollectibleByIdQuery(int id, CollectibleType collectibleType)
        {
            Id = id;
            CollectibleType = collectibleType;
        }
    }
}
