using MediatR;
using Portfolio.UI.Interfaces;
using Portfolio.UI.Requests.Commands;

namespace Portfolio.UI.Handlers.Commands
{
    public class SaveCoinHandler : IRequestHandler<SaveCoinCommand, int>
    {
        private readonly ICoinDataAccess _data;

        public SaveCoinHandler(ICoinDataAccess data) => _data = data;

        public async Task<int> Handle(SaveCoinCommand record, CancellationToken cancellationToken)
        {
            return await _data.SaveCoinAsync(record.Request);
        }
    }
}
