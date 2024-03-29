﻿using DocumentFormat.OpenXml.Packaging;
using Microsoft.AspNetCore.Components;
using OpenXmlPowerTools;
using Portfolio.Shared.Models;
using Portfolio.Shared.Repository;
using Portfolio.Shared.Requests.Collectibles.Coin;
using System.Text.Json;
using System.Xml.Linq;

namespace Portfolio.UI.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public PortfolioService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task AddCoinAsync(AddCoinRequest request)
        {
            var baseApiUrl = _configuration[Shared.Repository.Strings.BasePortfolioApiUrlKey];
            HttpRequestMessage httpRequest = new(HttpMethod.Post, $"{baseApiUrl}/inventory/coin/add");
            httpRequest.Content = JsonContent.Create(httpRequest);
            await _httpClient.SendAsync(httpRequest);
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
            }

            return html != null ? (MarkupString)html.ToString() : (MarkupString)"Failed to load resume.  Please try again later.";
        }

        public async Task<CoinModel?> GetCoinByIdAsync(int id)
        {
            CoinModel? coin = null;
            var baseApiUrl = _configuration.GetValue<string>(Shared.Repository.Strings.BasePortfolioApiUrlKey);
            using HttpRequestMessage request = new(HttpMethod.Get, $"{baseApiUrl}/coin/{id}");
            using var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                coin = await JsonSerializer.DeserializeAsync<CoinModel>(responseStream);
            }

            return coin;
        }

        public async Task<IEnumerable<DenominationModel>?> GetDenominationsAsync()
        {
            IEnumerable<DenominationModel>? denominations = null;
            var baseApiUrl = _configuration.GetValue<string>(Shared.Repository.Strings.BasePortfolioApiUrlKey);
            using HttpRequestMessage request = new(HttpMethod.Get, $"{baseApiUrl}/denomination/all");
            using var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                denominations = await JsonSerializer.DeserializeAsync<IEnumerable<DenominationModel>>(responseStream);
            }

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

        public async Task<IEnumerable<InventoryModel>> GetInventoryAsync()
        {
            List<InventoryModel> inventory = new();
            var baseApiUrl = _configuration.GetValue<string>(Shared.Repository.Strings.BasePortfolioApiUrlKey);

            if (!string.IsNullOrWhiteSpace(baseApiUrl))
            {
                using HttpRequestMessage request = new(HttpMethod.Get, $"{baseApiUrl}/inventory");
                using var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    inventory = await JsonSerializer.DeserializeAsync<List<InventoryModel>?>(responseStream) ?? new();
                }
            }

            return inventory;
        }

        public async Task<MapModel?> GetMapAsync(int id)
        {
            MapModel? map = null;
            var baseUri = _configuration.GetValue<string>(Shared.Repository.Strings.BasePortfolioApiUrlKey);

            if (!string.IsNullOrWhiteSpace(baseUri))
            {
                using HttpRequestMessage request = new(HttpMethod.Get, $"{baseUri}/map/{id}");
                using var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    map = await JsonSerializer.DeserializeAsync<MapModel>(responseStream);
                }
            }

            return map;
        }

        public async Task<IEnumerable<MapModel>> GetMapsAsync()
        {
            List<MapModel>? maps = null;
            var baseUrl = _configuration.GetValue<string>(Shared.Repository.Strings.BasePortfolioApiUrlKey);

            if (!string.IsNullOrWhiteSpace(baseUrl))
            {
                HttpRequestMessage request = new(HttpMethod.Get, $"{baseUrl}/map/all");
                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    maps = await JsonSerializer.DeserializeAsync<List<MapModel>>(responseStream);
                }
            }

            return maps ?? new();
        }

        public async Task<IEnumerable<MintModel>?> GetMintsAsync()
        {
            List<MintModel>? mints = null;
            var baseApiUrl = _configuration[Shared.Repository.Strings.BasePortfolioApiUrlKey];
            HttpRequestMessage request = new(HttpMethod.Get, $"{baseApiUrl}/mint/mints");
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                mints = await JsonSerializer.DeserializeAsync<List<MintModel>>(responseStream);
            }

            return mints;
        }

        public async Task UpdateCoinAsync(UpdateCoinRequest request)
        {
            var baseApiUrl = _configuration[Shared.Repository.Strings.BasePortfolioApiUrlKey];
            HttpRequestMessage httpRequest = new(HttpMethod.Post, $"{baseApiUrl}/coin/update");
            httpRequest.Content = JsonContent.Create(httpRequest);
            await _httpClient.SendAsync(httpRequest);
        }
    }
}
