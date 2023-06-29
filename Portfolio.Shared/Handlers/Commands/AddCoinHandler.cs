using MediatR;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Requests.Commands;
using static Portfolio.Shared.Requests.Commands.AddCoinCommand;

namespace Portfolio.Shared.Handlers.Commands
{
    public class AddCoinHandler : IRequestHandler<AddCoinCommand, int>
    {
        private readonly ICoinDataAccess _data;

        public AddCoinHandler(ICoinDataAccess data) => _data = data;

        public async Task<int> Handle(AddCoinCommand record, CancellationToken cancellationToken)
        {
            return await _data.AddCoinAsync(record.Request);
        }
    }
}
