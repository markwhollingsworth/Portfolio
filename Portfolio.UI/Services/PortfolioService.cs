using DocumentFormat.OpenXml.Packaging;
using Microsoft.AspNetCore.Components;
using OpenXmlPowerTools;
using Portfolio.Shared.Models.Collectibles;
using Portfolio.UI.Handlers.Commands;
using Portfolio.UI.Handlers.Queries;
using Portfolio.UI.Interfaces;
using Portfolio.UI.Models;
using Portfolio.UI.Requests.Collectibles;
using Portfolio.UI.Requests.Commands;
using Portfolio.UI.Requests.Queries;
using System.Xml.Linq;

namespace Portfolio.UI.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapDataAccess _mapDataAccess;
        private readonly ICoinDataAccess _coinDataAccess;
        private readonly HttpClient _httpClient;

        public PortfolioService(IConfiguration configuration,
                                ICoinDataAccess coinDataAccess,
                                IMapDataAccess mapDataAccess,
                                HttpClient httpClient)
        {
            _configuration = configuration;
            _coinDataAccess = coinDataAccess;
            _mapDataAccess = mapDataAccess;
            _httpClient = httpClient;
        }

        public async Task<MarkupString> ConvertDocumentToHtmlAsync(string key)
        {
            XElement? html = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    byte[] fileContents;
                    var documentUrl = _configuration.GetValue<string>(key);
                    HttpRequestMessage request = new(HttpMethod.Get, documentUrl);
                    var response = await _httpClient.SendAsync(request);
                    fileContents = await response.Content.ReadAsByteArrayAsync();

                    using MemoryStream memoryStream = new();
                    await memoryStream.WriteAsync(fileContents, 0, fileContents.Length);
                    using var doc = WordprocessingDocument.Open(memoryStream, true);
                    HtmlConverterSettings settings = new();
                    html = HtmlConverter.ConvertToHtml(doc, settings);
                }
            }
            catch (Exception ex)
            {
                // log exception - TODO
            }

            return html != null ? (MarkupString)html.ToString() : (MarkupString)"Failed to load resume.  Please try again later.";
        }

        public async Task<CoinModel?> GetCoinByIdAsync(int id)
        {
            var handler = new GetCoinByIdHandler(_coinDataAccess);
            var request = new GetCoinByIdQuery(id);
            var coin = await handler.Handle(request, new CancellationToken());
            return coin;
        }

        public async Task<IEnumerable<InventoryModel>?> GetCoinsAsync()
        {
            var handler = new GetCoinsHandler(_coinDataAccess);
            var request = new GetCoinsQuery();
            var coins = await handler.Handle(request, new CancellationToken());
            return coins;
        }

        public async Task<IEnumerable<DenominationModel>?> GetDenominationsAsync()
        {
            var handler = new GetDenominationsHandler(_coinDataAccess);
            var request = new GetDenominationsQuery();
            var denominations = await handler.Handle(request, new CancellationToken());
            return denominations;
        }

        public IEnumerable<MapModel>? GetFilteredMaps(IEnumerable<MapModel>? maps, string? searchText)
        {
            List<MapModel>? filteredMaps = null;

            if (maps != null && !string.IsNullOrWhiteSpace(searchText))
            {
                bool isMatchForSearchText(MapModel model)
                {
                    return (model.Description != null && model.Description.Contains(searchText, StringComparison.OrdinalIgnoreCase)) ||
                           (model.Year != null && model.Year.Contains(searchText, StringComparison.OrdinalIgnoreCase)) ||
                           (model.Month != null && model.Month.Contains(searchText, StringComparison.OrdinalIgnoreCase));
                };

                filteredMaps = maps.Where(isMatchForSearchText).ToList();
            }

            return filteredMaps;
        }

        public async Task<IEnumerable<GradingCompanyModel>?> GetGradingCompaniesAsync()
        {
            var handler = new GetGradingCompaniesHandler(_coinDataAccess);
            var request = new GetGradingCompaniesQuery();
            var gradingCompanies = await handler.Handle(request, new CancellationToken());
            return gradingCompanies;
        }

        public async Task<MapModel?> GetMapByIdAsync(int id)
        {
            var handler = new GetMapByIdHandler(_mapDataAccess);
            var map = await handler.Handle(new GetMapByIdQuery(id), new CancellationToken());
            return map;
        }

        public async Task<IEnumerable<MapModel>?> GetMapsAsync()
        {
            var handler = new GetMapsHandler(_mapDataAccess);
            var maps = await handler.Handle(new GetMapsQuery(), new CancellationToken());
            return maps;
        }

        public async Task<MintModel?> GetMintByIdAsync(int id)
        {
            var handler = new GetMintByIdHandler(_coinDataAccess);
            var request = new GetMintByIdQuery(id);
            var mint = await handler.Handle(request, new CancellationToken());
            return mint;
        }

        public async Task<IEnumerable<MintModel>?> GetMintsAsync()
        {
            var handler = new GetMintsHandler(_coinDataAccess);
            var mints = await handler.Handle(new GetMintsQuery(), new CancellationToken());
            return mints;
        }

        public async Task<PurchaseDetailModel?> GetPurchaseDetailByIdAsync(int id)
        {
            var handler = new GetPurchaseDetailByIdHandler(_coinDataAccess);
            var purchaseDetail = await handler.Handle(new GetPurchaseDetailByIdQuery(id), new CancellationToken());
            return purchaseDetail;
        }

        public async Task<int> SaveCoinAsync(SaveCoinRequest request)
        {
            var handler = new SaveCoinHandler(_coinDataAccess);
            var command = new SaveCoinCommand(request);
            var rowsAffected = await handler.Handle(command, new CancellationToken());
            return rowsAffected;
        }
    }
}
