using MediatR;
using Portfolio.Shared.Models.Collectibles;
using Portfolio.UI.Interfaces;
using Portfolio.UI.Requests.Queries;

namespace Portfolio.UI.Handlers.Queries
{
    public class GetGradingCompaniesHandler : IRequestHandler<GetGradingCompaniesQuery, IEnumerable<GradingCompanyModel>?>
    {
        private readonly ICoinDataAccess _data;

        public GetGradingCompaniesHandler(ICoinDataAccess data) => _data = data;

        public async Task<IEnumerable<GradingCompanyModel>?> Handle(GetGradingCompaniesQuery request, CancellationToken cancellationToken)
        {
            return await _data.GetGradingCompaniesAsync();
        }
    }
}
