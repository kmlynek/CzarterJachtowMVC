using Firma.Data.Data.Flota;
using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Data.Flota
{
    public class Port
    {
        [Key]
        public int IdPortu { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Nazwa portu")]
        public string Nazwa { get; set; }

        [MaxLength(100)]
        [Display(Name = "Lokalizacja")]
        public string? Lokalizacja { get; set; }

        public ICollection<Jacht> Jachty { get; set; } = new List<Jacht>();
    }
}