using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Portfolio.Shared.Models.Collectibles;
using Portfolio.Shared.Repository;
using Portfolio.UI.Configuration;
using Portfolio.UI.Interfaces;
using Portfolio.UI.Models;
using Portfolio.UI.Requests.Collectibles;

namespace Portfolio.UI.DataAccess
{
    public class CoinDataAccess : ICoinDataAccess
    {
        private DataAccessConfiguration _configuration;

        public CoinDataAccess(ILogger<ICoinDataAccess> logger, IConfiguration configuration)
        {
            _configuration = new(logger, configuration);
        }

        /// <summary>
        /// Gets all coins.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<InventoryModel>?> GetCoinsAsync()
        {
            _configuration.Logger.LogInformation($"Calling method {nameof(GetCoinsAsync)}");
            IEnumerable<InventoryModel>? result = null;

            try
            {
                using SqlConnection connection = new(_configuration.ConnectionString);
                result = await connection.QueryAsync<InventoryModel>(Strings.GetCoinsProc,
                                                                     null,
                                                                     null,
                                                                     _configuration.CommandTimeout,
                                                                     _configuration.CommandType);
            }
            catch (Exception ex)
            {
                _configuration.Logger.LogError(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Gets mints.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MintModel>?> GetMintsAsync()
        {
            _configuration.Logger.LogInformation($"Calling method {nameof(GetMintsAsync)}");
            IEnumerable<MintModel>? mints = null;

            try
            {
                using SqlConnection connection = new(_configuration.ConnectionString);
                mints = await connection.QueryAsync<MintModel>(Strings.GetMintsProc,
                                                               null,
                                                               null,
                                                               _configuration.CommandTimeout,
                                                               _configuration.CommandType);
            }
            catch (Exception ex)
            {
                _configuration.Logger.LogError(ex.Message);
            }

            return mints;
        }

        /// <summary>
        /// Gets a mint by id.
        /// </summary>
        /// <returns></returns>
        public async Task<MintModel?> GetMintByIdAsync(int id)
        {
            _configuration.Logger.LogInformation($"Calling method {nameof(GetMintByIdAsync)}");
            MintModel? mint = null;

            try
            {
                using SqlConnection connection = new(_configuration.ConnectionString);
                var parameters = new { Id = id };
                mint = await connection.QueryFirstOrDefaultAsync<MintModel>(Strings.GetMintByIdProc,
                                                                            parameters,
                                                                            null,
                                                                            _configuration.CommandTimeout,
                                                                            _configuration.CommandType);
            }
            catch (Exception ex)
            {
                _configuration.Logger.LogError(ex.Message);
            }

            return mint;
        }

        /// <summary>
        /// Gets coin denominations.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DenominationModel>?> GetDenominationsAsync()
        {
            _configuration.Logger.LogInformation($"Calling method {nameof(GetDenominationsAsync)}");
            IEnumerable<DenominationModel>? denominations = null;

            try
            {
                using SqlConnection connection = new(_configuration.ConnectionString);
                denominations = await connection.QueryAsync<DenominationModel>(Strings.GetDenominationsProc,
                                                                               null,
                                                                               null,
                                                                               _configuration.CommandTimeout,
                                                                               _configuration.CommandType);
            }
            catch (Exception ex)
            {
                _configuration.Logger.Log(LogLevel.Error, ex.Message);
            }

            return denominations;
        }

        /// <summary>
        /// Gets all grading companies
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GradingCompanyModel>?> GetGradingCompaniesAsync()
        {
            _configuration.Logger.LogInformation($"Calling method {nameof(GetGradingCompaniesAsync)}");
            IEnumerable<GradingCompanyModel>? gradingCompanies = null;

            try
            {
                using SqlConnection connection = new(_configuration.ConnectionString);
                gradingCompanies = (await connection.QueryAsync<GradingCompanyModel>(Strings.GetGradingCompaniesProc,
                                                                                     null,
                                                                                     null,
                                                                                     _configuration.CommandTimeout,
                                                                                     _configuration.CommandType));
            }
            catch (Exception ex)
            {
                _configuration.Logger.Log(LogLevel.Error, ex.Message);
            }

            return gradingCompanies;
        }

        /// <summary>
        /// Gets a coin
        /// </summary>
        /// <param name="id">The id, of type int, of the coin</param>
        /// <returns>Returns details about the coin.</returns>
        public async Task<CoinModel?> GetCoinByIdAsync(int id)
        {
            _configuration.Logger.LogInformation($"Calling method {nameof(GetCoinByIdAsync)} with {nameof(id)} of {id}");
            CoinModel? result = null;

            try
            {
                using SqlConnection connection = new(_configuration.ConnectionString);
                var parameters = new { Id = id };
                result = await connection.QueryFirstOrDefaultAsync<CoinModel>(Strings.GetCoinByIdProc,
                                                                              parameters,
                                                                              null,
                                                                              _configuration.CommandTimeout,
                                                                              _configuration.CommandType);
            }
            catch (Exception ex)
            {
                _configuration.Logger.LogError(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Gets the purchase details.
        /// </summary>
        /// <param name="id">The id, of type int, of the purchase detail.</param>
        /// <returns>Returns purchase details.</returns>
        public async Task<PurchaseDetailModel?> GetPurchaseDetailByIdAsync(int id)
        {
            _configuration.Logger.LogInformation($"Calling method {nameof(GetPurchaseDetailByIdAsync)} with {nameof(id)} of {id}");
            PurchaseDetailModel? result = null;

            try
            {
                using SqlConnection connection = new(_configuration.ConnectionString);
                var parameters = new { Id = id };
                result = await connection.QueryFirstOrDefaultAsync<PurchaseDetailModel>(Strings.GetPurchaseDetailByIdProc,
                                                                                        parameters,
                                                                                        null,
                                                                                        _configuration.CommandTimeout,
                                                                                        _configuration.CommandType);
            }
            catch (Exception ex)
            {
                _configuration.Logger.LogError(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Saves a coin to the database.
        /// </summary>
        /// <param name="request">The request containing details about the coin to save.</param>
        /// <returns>Returns the number of rows affected.</returns>
        public async Task<int> SaveCoinAsync(SaveCoinRequest request)
        {
            _configuration.Logger.LogInformation($"Calling method {nameof(SaveCoinAsync)}");
            if (request == null)
            {
                throw new ArgumentNullException("Request can not be null.");
            }

            var rowsAffected = 0;

            try
             {
                using SqlConnection connection = new(_configuration.ConnectionString);
                var parameters = new
                {
                    request.Year,
                    request.ListPrice,
                    request.Description,
                    request.Quantity,
                    request.PurchaseDetail.Subtotal,
                    request.PurchaseDetail.Shipping,
                    request.PurchaseDetail.Tax,
                    Total = CalculateTotal(request),
                    request.PurchaseDetail.Date,
                    request.PurchaseDetail.SellerName,
                    request.PurchaseDetail.SellerAddress,
                    request.MintId,
                    request.DenominationId,
                    GradingCompanyId = request.GradedBy,
                    request.Grade
                };

                rowsAffected = await connection.ExecuteAsync(Strings.SaveCoinProc, 
                                                             parameters, 
                                                             null, 
                                                             _configuration.CommandTimeout, 
                                                             _configuration.CommandType);
            }
            catch (Exception ex)
            {
                _configuration.Logger.LogError(ex.Message);
            }

            return rowsAffected;
        }

        private decimal CalculateTotal(SaveCoinRequest request)
        {
            var total = 0.00m;

            if (request?.PurchaseDetail != null)
            {
                total = request.PurchaseDetail.Subtotal + request.PurchaseDetail.Shipping + request.PurchaseDetail.Tax;
            }

            return total;
        }
    }
}
