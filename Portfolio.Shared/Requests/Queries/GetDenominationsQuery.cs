using MediatR;
using Portfolio.UI.Models;

namespace Portfolio.UI.Requests.Queries
{
    public class GetDenominationsQuery : IRequest<IEnumerable<DenominationModel>?>
    {
        public record GetDenominations() : IRequest<IEnumerable<DenominationModel>?>;
    }
}