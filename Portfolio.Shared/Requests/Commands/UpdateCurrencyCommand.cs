using MediatR;

namespace Portfolio.Shared.Requests.Commands
{
    public class UpdateCurrencyCommand : IRequest<int>
    {
        public UpdateCurrencyRequest Request { get; set; }

        public UpdateCurrencyCommand(UpdateCurrencyRequest request) => Request = request;
    }
}
