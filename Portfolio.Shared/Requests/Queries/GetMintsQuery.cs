using MediatR;
using Portfolio.UI.Models;

namespace Portfolio.UI.Requests.Queries
{
    public class GetMintsQuery : IRequest<IEnumerable<MintModel>?>
    {
        public record GetMints() : IRequest<IEnumerable<MintModel>?>;
    }
}
