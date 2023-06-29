using MediatR;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Models;
using Portfolio.Shared.Requests.Queries;

namespace Portfolio.Shared.Handlers.Queries
{
    public class GetDenominationsHandler : IRequestHandler<GetDenominationsQuery, IEnumerable<DenominationModel>?>
    {
        private readonly IDenominationDataAccess _data;

        public GetDenominationsHandler(IDenominationDataAccess data) => _data = data;

        public async Task<IEnumerable<DenominationModel>?> Handle(GetDenominationsQuery request, CancellationToken cancellationToken)
        {
            return await _data.GetDenominationsAsync();
        }
    }
}
