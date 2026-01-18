using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Components;
using Portfolio.UI.Requests.Collectibles;
using Portfolio.UI.Services;

namespace Portfolio.UI.Pages
{
    public partial class EditCoin
    {
        #region Properties

        private Dictionary<int, string>? Denominations { get; set; }

        private Dictionary<int, string>? GradingCompanies { get; set; }

        private bool IsLoadingComplete { get; set; }

        private bool IsSaveCoinSuccessful { get; set; }

        private Dictionary<int, string>? Mints { get; set; }

        private string SaveCoinMessage {get;set;} = "Success! Coin was updated in inventory.";

        private SaveCoinRequest SaveCoinRequest { get; set; } = new() { Year = DateTime.Now.Year.ToString(), Description = string.Empty };

        [Inject]
        public required IPortfolioService PortfolioService { get; set; }

        [Inject]
        public required IConfiguration Configuration { get; set; }

        public string? SelectedDenomination { get; set; }

        public string? SelectedMintMark { get; set; }

        public string? SelectedGradingCompany { get; set; }

        #endregion Properties

        #region Blazor

        protected override async Task OnInitializedAsync()
        {
            GradingCompanies = await BuildGradingCompaniesDropdownAsync(); // todo
            Mints = await BuildMintsDropdownAsync();
            Denominations = await BuildDenominationsDropdownAsync();
            IsLoadingComplete = true;
        }

        #endregion

        #region Private methods

        private async Task<Dictionary<int, string>?> BuildGradingCompaniesDropdownAsync()
        {
            Dictionary<int, string>? result = null;
            var gradingCompanies = (await PortfolioService.GetGradingCompaniesAsync())?.OrderBy(x => x.Description)?.ToList();

            if (gradingCompanies?.Count > 0)
            {
                result = new Dictionary<int, string>();
                foreach (var gradingCompany in gradingCompanies)
                {
                    result.Add(gradingCompany!.Id, gradingCompany!.Abbreviation ?? string.Empty);
                }
            }

            return result;
        }

        private async Task<Dictionary<int, string>?> BuildDenominationsDropdownAsync()
        {
            Dictionary<int, string>? result = null;
            var denominations = (await PortfolioService.GetDenominationsAsync())?.OrderBy(x => x.Description)?.ToList();

            if (denominations?.Count > 0)
            {
                result = new Dictionary<int, string>();
                foreach (var denomination in denominations)
                {
                    result.Add(denomination!.Id, denomination!.Description ?? string.Empty);
                }
            }

            return result;
        }

        private async Task<Dictionary<int, string>?> BuildMintsDropdownAsync()
        {
            Dictionary<int, string>? result = null;
            var mints = (await PortfolioService.GetMintsAsync())?.OrderBy(x => x.Name)?.ToList();

            if (mints?.Count > 0)
            {
                result = new Dictionary<int, string>();
                foreach (var mint in mints)
                {
                    result.Add(mint!.Id, $"{mint!.Name} ({mint!.Abbreviation})" ?? string.Empty);
                }
            }

            return result;
        }

        private async Task<int> SaveCoin()
        {
            var result = await PortfolioService.SaveCoinAsync(SaveCoinRequest);
            IsSaveCoinSuccessful = true;
            return result;
        }

        #endregion Private methods
    }
}
