using MediatR;
using Portfolio.UI.Models;

namespace Portfolio.UI.Requests.Queries
{
    public class GetMintByIdQuery : IRequest<MintModel>
    {
        public int Id { get; set; }

        public GetMintByIdQuery(int id)
        {
            Id = id;
        }
    }
}
