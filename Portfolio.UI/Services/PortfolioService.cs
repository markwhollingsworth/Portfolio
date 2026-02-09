using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Components;
using OpenXmlPowerTools;
using Portfolio.Shared.Enums;
using Portfolio.Shared.Handlers.Commands;
using Portfolio.Shared.Handlers.Queries;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Models;
using Portfolio.Shared.Requests.Collectibles;
using Portfolio.Shared.Requests.Commands;
using Portfolio.Shared.Requests.Queries;
using System.Xml.Linq;
using static Portfolio.Shared.Requests.Queries.GetInventoryQuery;

namespace Portfolio.UI.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ICollectibleDataAccess _collectibleDataAccess;
        private readonly IDenominationDataAccess _denominationDataAccess;
        private readonly IInventoryDataAccess _inventoryDataAccess;
        private readonly IMapDataAccess _mapDataAccess;
        private readonly IMintDataAccess _mintDataAccess;

        public PortfolioService(HttpClient httpClient, IConfiguration configuration, ICollectibleDataAccess collectibleDataAccess,
            IDenominationDataAccess denominationDataAccess, IInventoryDataAccess inventoryDataAccess, IMapDataAccess mapDataAccess, IMintDataAccess mintDataAccess)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _collectibleDataAccess = collectibleDataAccess;
            _denominationDataAccess = denominationDataAccess;
            _inventoryDataAccess = inventoryDataAccess;
            _mapDataAccess = mapDataAccess;
            _mintDataAccess = mintDataAccess;
        }

        public async Task<int> AddCollectibleAsync(AddCollectibleRequest request)
        {
            var handler = new AddCollectibleHandler(_collectibleDataAccess);
            var command = new AddCollectibleCommand(request);
            var rowsAffected = await handler.Handle(command, new CancellationToken());
            return rowsAffected;
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
            catch (Exception)
            {
            }

            return html != null ? (MarkupString)html.ToString() : (MarkupString)"Failed to load resume.  Please try again later.";
        }

        public async Task<CollectibleModel?> GetCollectibleByIdAsync(int id, CollectibleType collectibleType)
        {
            var handler = new GetCollectibleByIdHandler(_collectibleDataAccess);
            var request = new GetCollectibleByIdQuery(id, collectibleType);
            var collectible = await handler.Handle(request, new CancellationToken());
            return collectible;
        }

        public async Task<IEnumerable<DenominationModel>?> GetDenominationsAsync()
        {
            var handler = new GetDenominationsHandler(_denominationDataAccess);
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

        //public async Task<PaginatedResult<InventoryModel>?> GetInventoryAsync(int pageNumber = 1, int pageSize = 10)
        public async Task<PaginatedResult<InventoryModel>?> GetInventoryAsync(SearchCriteria searchCriteria)
        {
            var handler = new GetInventoryHandler(_inventoryDataAccess);
            //var request = new GetInventoryQuery(pageNumber, pageSize);
            var request = new GetInventoryQuery(searchCriteria);
            var inventory = await handler.Handle(request, new CancellationToken());
            return inventory;
        }

        public async Task<MapModel?> GetMapByIdAsync(Guid id)
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

        public async Task<IEnumerable<MintModel>?> GetMintsAsync()
        {
            var handler = new GetMintsHandler(_mintDataAccess);
            var mints = await handler.Handle(new GetMintsQuery(), new CancellationToken());
            return mints;
        }
    }
}
