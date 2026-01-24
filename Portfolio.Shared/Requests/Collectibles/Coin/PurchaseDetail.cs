using Portfolio.Shared.Repository;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.UI.Requests.Collectibles
{
    public class PurchaseDetail
    {
        public Guid Id { get; set; }

        [RegularExpression("^(\\()?[0-9]+(?>,[0-9]{3})*(?>\\.[0-9]{2})?(?(1)\\))$")]
        public decimal Subtotal { get; set; } = 0m;

        [RegularExpression("^(\\()?[0-9]+(?>,[0-9]{3})*(?>\\.[0-9]{2})?(?(1)\\))$")]
        public decimal Shipping { get; set; } = 0m;

        [RegularExpression("^(\\()?[0-9]+(?>,[0-9]{3})*(?>\\.[0-9]{2})?(?(1)\\))$")]
        public decimal Tax { get; set; } = 0m;

        [RegularExpression("^(\\()?[0-9]+(?>,[0-9]{3})*(?>\\.[0-9]{2})?(?(1)\\))$")]
        public decimal Total { get; set; } = 0m;
        public string Date { get; set; } = DateTime.Today.ToShortDateString();
        public string? SellerName { get; set; }
        public string? SellerAddress { get; set; }

        [Required(ErrorMessage = Strings.QuantityIsRequired)]
        [Range(1, int.MaxValue, ErrorMessage = Strings.QuantityMustBeAtLeastOne)]
        public int Quantity { get; set; }
        public Guid CoinId { get; set; }
    }
}
