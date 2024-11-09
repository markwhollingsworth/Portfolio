using MediatR;
using Portfolio.Shared.Requests.Collectibles;

namespace Portfolio.Shared.Requests.Commands
{
    public class AddCollectibleCommand : IRequest<int>
    {
        public AddCollectibleRequest Request { get; set; }

        public AddCollectibleCommand(AddCollectibleRequest request) => Request = request;
    }
}