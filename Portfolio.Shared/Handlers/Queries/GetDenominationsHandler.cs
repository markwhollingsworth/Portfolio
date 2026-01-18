using MediatR;
using Portfolio.UI.Interfaces;
using Portfolio.UI.Models;
using Portfolio.UI.Requests.Queries;

namespace Portfolio.UI.Handlers.Queries
{
    public class GetDenominationsHandler : IRequestHandler<GetDenominationsQuery, IEnumerable<DenominationModel>?>
    {
        private readonly ICoinDataAccess _data;

        public GetDenominationsHandler(ICoinDataAccess data) => _data = data;

        public async Task<IEnumerable<DenominationModel>?> Handle(GetDenominationsQuery request, CancellationToken cancellationToken)
        {
            return await _data.GetDenominationsAsync();
        }
    }
}
