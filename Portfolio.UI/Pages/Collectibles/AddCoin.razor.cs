using Portfolio.Common.Models.Collectibles;
using Portfolio.Common.Requests.Collectibles.Coin;
using System.Net.Http.Json;
using System.Text.Json;

namespace Portfolio.UI.Pages.Collectibles
{
    public partial class AddCoin
    {
        #region Properties

        private List<MintModel> Mints { get; set; } = new List<MintModel>();
        private List<DenominationModel> Denominations { get; set; } = new List<DenominationModel>();
        private AddCoinRequest AddCoinRequest { get; set; } = new AddCoinRequest();
        private bool IsLoadingComplete { get; set; } = false;
        private bool IsAddCoinSuccessful { get; set; } = false;
        private string AddCoinMessage { get; set; } = "Success!  Coin was added to inventory.";

        #endregion Properties

        #region Methods

        private async Task SaveCoin()
        {
            // Validation

            var baseApiUrl = Configuration["BaseCollectibleApiUrl"];
            var request = new HttpRequestMessage(HttpMethod.Post, $"{baseApiUrl}api/inventory/coin/add");
            request.Content = JsonContent.Create(AddCoinRequest);

            var client = ClientFactory.CreateClient("api");
            var response = await client.SendAsync(request);

            IsAddCoinSuccessful = response.IsSuccessStatusCode ? true : false;
            var mint = Mints.First(x => x.Id == Convert.ToInt32(AddCoinRequest.MintId));
            var denomination = Denominations.First(x => x.Id == Convert.ToInt32(AddCoinRequest.DenominationId));
            AddCoinMessage = $"An {AddCoinRequest.Year}-{mint.Abbreviation} {denomination.Description} was added to inventory.";
        }

        private async Task<List<MintModel>> GetMintsAsync()
        {
            List<MintModel>? mints = null;
            var baseApiUrl = Configuration["BaseCollectibleApiUrl"];
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseApiUrl}api/mint/all");

            var client = ClientFactory.CreateClient("api");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                mints = await JsonSerializer.DeserializeAsync<List<MintModel>>(responseStream);
            }

            return mints ?? new List<MintModel>();
        }

        private async Task<List<DenominationModel>> GetDenominationsAsync()
        {
            List<DenominationModel>? denominations = null;
            var baseApiUrl = Configuration.GetValue<string>("BaseCollectibleApiUrl");
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseApiUrl}api/denomination/all");

            var client = ClientFactory.CreateClient("api");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                denominations = await JsonSerializer.DeserializeAsync<List<DenominationModel>>(responseStream);
            }

            return denominations ?? new List<DenominationModel>();
        }

        #endregion Methods

        #region Lifecycle

        protected override async Task OnInitializedAsync()
        {
            Mints = (await GetMintsAsync()).OrderBy(x => x.Name).ToList();
            Denominations = (await GetDenominationsAsync()).OrderBy(x => x.Description).ToList();
            IsLoadingComplete = true;
        }

        #endregion Lifecycle
    }
}
