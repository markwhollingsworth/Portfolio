using MediatR;
using Portfolio.Shared.Models;

namespace Portfolio.Shared.Requests.Queries
{
    public class GetDenominationsQuery : IRequest<IEnumerable<DenominationModel>?>
    {
        public record GetDenominations() : IRequest<IEnumerable<DenominationModel>?>;
    }
}