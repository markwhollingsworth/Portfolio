using MediatR;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Requests.Commands;

namespace Portfolio.Shared.Handlers.Commands
{
    public class AddCollectibleHandler : IRequestHandler<AddCollectibleCommand, int>
    {
        private readonly ICollectibleDataAccess _data;

        public AddCollectibleHandler(ICollectibleDataAccess data) => _data = data;

        public async Task<int> Handle(AddCollectibleCommand record, CancellationToken cancellationToken)
        {
            return await _data.SaveCollectibleAsync(record.Request);
        }
    }
}
