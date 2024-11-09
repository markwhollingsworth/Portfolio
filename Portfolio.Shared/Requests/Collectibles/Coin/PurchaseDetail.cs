using System.ComponentModel.DataAnnotations;

namespace Portfolio.Shared.Requests.Collectibles
{
    public class PurchaseDetail
    {
        public Guid Id { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal Shipping { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public string Date { get; set; } = DateTime.Today.ToShortDateString();
        public string? SellerName { get; set; }
        public string? SellerAddress { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
        public Guid CoinId { get; set; }
    }
}
