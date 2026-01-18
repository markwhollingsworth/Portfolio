using MediatR;
using Portfolio.UI.Requests.Collectibles;

namespace Portfolio.UI.Requests.Commands
{
    public class SaveCoinCommand : IRequest<int>
    {
        public SaveCoinRequest Request { get; set; }

        public SaveCoinCommand(SaveCoinRequest request) => Request = request;
    }
}