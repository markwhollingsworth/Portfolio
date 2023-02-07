using Portfolio.Common.Enums.Collectibles;

namespace Portfolio.Common.Models.Collectibles
{
    public class InventoryModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal ListPrice { get; set; }
        public Denomination Denomination { get; set; }
        public Mint Mint { get; set; }
        public int Quantity { get; set; }
    }
}

