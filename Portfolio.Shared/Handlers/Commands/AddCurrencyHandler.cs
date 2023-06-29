using MediatR;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Requests.Commands;

namespace Portfolio.Shared.Handlers.Commands
{
    public class AddCurrencyHandler : IRequestHandler<AddCurrencyCommand, int>
    {
        private readonly ICurrencyDataAccess _data;

        public AddCurrencyHandler(ICurrencyDataAccess data) => _data = data;

        public async Task<int> Handle(AddCurrencyCommand request, CancellationToken cancellationToken)
        {
            return await _data.AddCurrencyAsync(request.Request);
        }
    }
}
