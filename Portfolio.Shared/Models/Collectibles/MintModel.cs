using System.ComponentModel.DataAnnotations;

namespace Portfolio.UI.Models
{
    public class MintModel
    {
        [Range(int.MinValue, int.MaxValue)]
        public int Id { get; set; }

        [StringLength(5)]
        public string? Abbreviation { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }

        public bool IsActive { get; set; }
    }
}
