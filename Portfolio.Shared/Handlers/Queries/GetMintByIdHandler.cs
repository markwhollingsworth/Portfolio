using MediatR;
using Portfolio.UI.Interfaces;
using Portfolio.UI.Models;
using Portfolio.UI.Requests.Queries;

namespace Portfolio.UI.Handlers.Queries
{
    public class GetMintByIdHandler : IRequestHandler<GetMintByIdQuery, MintModel?>
    {
        private readonly ICoinDataAccess _data;

        public GetMintByIdHandler(ICoinDataAccess data) => _data = data;

        public async Task<MintModel?> Handle(GetMintByIdQuery request, CancellationToken cancellationToken)
        {
            return await _data.GetMintByIdAsync(request.Id);
        }
    }
}

