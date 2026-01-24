using MediatR;
using Portfolio.Shared.Models;

namespace Portfolio.Shared.Requests.Queries
{
    public class GetMintsQuery : IRequest<IEnumerable<MintModel>?>
    {
        public record GetMints() : IRequest<IEnumerable<MintModel>?>;
    }
}
