using System.ComponentModel.DataAnnotations;

namespace Portfolio.UI.Models
{
    public class DenominationModel
    {
        [Range(int.MinValue, int.MaxValue)]
        public int Id { get; set; }

        [StringLength(100)]
        public required string Description { get; set; }
    }
}