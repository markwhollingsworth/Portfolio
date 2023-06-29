using MediatR;

namespace Portfolio.Shared.Requests.Commands
{
    public class AddCurrencyCommand :IRequest<int>
    {
        public AddCurrencyRequest Request { get; set; }

        public AddCurrencyCommand(AddCurrencyRequest request) => Request = request;
    }
}
