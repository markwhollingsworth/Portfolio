using MediatR;
using Portfolio.Shared.Models.Collectibles;

namespace Portfolio.UI.Requests.Queries
{
    public class GetGradingCompaniesQuery : IRequest<IEnumerable<GradingCompanyModel>?>
    {
        public record GetGradingCompanies() : IRequest<IEnumerable<GradingCompanyModel>?>;
    }
}