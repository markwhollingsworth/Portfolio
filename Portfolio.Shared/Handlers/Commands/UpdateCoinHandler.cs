using MediatR;
using Portfolio.Shared.Interfaces;
using static Portfolio.Shared.Requests.Commands.UpdateCoinCommand;

namespace Portfolio.Shared.Handlers.Commands
{
    public class UpdateCoinHandler : IRequestHandler<UpdateCoinRecord, int>
    {
        private readonly ICoinDataAccess _data;

        public UpdateCoinHandler(ICoinDataAccess data) => _data = data;

        public async Task<int> Handle(UpdateCoinRecord record, CancellationToken cancellationToken)
        {
            return await _data.UpdateCoinAsync(record.Request);
        }
    }
}
