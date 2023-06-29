using MediatR;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Models;
using Portfolio.Shared.Requests.Queries;

namespace Portfolio.Shared.Handlers.Queries
{
    public class GetCurrencyByIdHandler : IRequestHandler<GetCurrencyByIdQuery, CurrencyModel?>
    {
        private readonly ICurrencyDataAccess _data;

        public GetCurrencyByIdHandler(ICurrencyDataAccess data) => _data = data;

        public async Task<CurrencyModel?> Handle(GetCurrencyByIdQuery request, CancellationToken cancellationToken)
        {
            return await _data.GetCurrencyByIdAsync(request.Id);
        }
    }
}
