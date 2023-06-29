using MediatR;
using Portfolio.Shared.Requests.Collectibles.Coin;

namespace Portfolio.Shared.Requests.Commands
{
    public class AddCoinCommand : IRequest<int>
    {
        public AddCoinRequest Request { get; set; }

        public AddCoinCommand(AddCoinRequest request) => Request = request;
    }
}