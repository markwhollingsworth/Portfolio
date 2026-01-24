using System.ComponentModel.DataAnnotations;

namespace Portfolio.Shared.Models.Collectibles
{
    public class PurchaseDetailModel
    {
        [Range(int.MinValue, int.MaxValue)]
        public int Id { get; set; }

        public decimal? Subtotal { get; set; }

        public decimal? Shipping { get; set; }

        public decimal? Tax { get; set; }

        public decimal? Total { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(250)]
        public string? SellerName { get; set; }

        [StringLength(500)]
        public string? SellerAddress { get; set; }

        [Range(int.MinValue, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(int.MinValue, int.MaxValue)]
        public int CoinId { get; set; }
    }
}
