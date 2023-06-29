using MediatR;
using Portfolio.Shared.Requests.Collectibles.Coin;

namespace Portfolio.Shared.Requests.Commands
{
    public class UpdateCoinCommand : IRequest<int>
    {
        private UpdateCoinRequest Request { get; set; }

        public UpdateCoinCommand(UpdateCoinRequest request) => Request = request;

        public record UpdateCoinRecord(UpdateCoinRequest Request) : IRequest<int>;
    }
}