using System.ComponentModel.DataAnnotations;

namespace Portfolio.Shared.Requests.Collectibles.Coin
{
    public class AddCoinRequest
    {
        [Required(ErrorMessage = "Year is required")]
        public string Year { get; set; }

        [Required(ErrorMessage = "List price is required")]
        public decimal ListPrice { get; set; }

        [Required(ErrorMessage = "Mint is required")]
        public string MintId { get; set; }

        [Required(ErrorMessage = "Denomination is required")]
        public string DenominationId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public string Quantity { get; set; }
    }
}