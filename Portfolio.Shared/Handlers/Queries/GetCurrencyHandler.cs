using MediatR;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Models;
using Portfolio.Shared.Requests.Queries;

namespace Portfolio.Shared.Handlers.Queries
{
    public class GetCurrencyHandler : IRequestHandler<GetCurrencyQuery, IEnumerable<CurrencyModel>?>
    {
        private readonly ICurrencyDataAccess _data;

        public GetCurrencyHandler(ICurrencyDataAccess data) => _data = data;

        public async Task<IEnumerable<CurrencyModel>?> Handle(GetCurrencyQuery request, CancellationToken cancellationToken)
        {
            return await _data.GetAllCurrencyAsync();
        }
    }
}