using Firma.Data.Data.Flota;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Data.Flota
{
    public class KategoriaJachtu
    {
        [Key]
        public int IdKategorii { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Nazwa kategorii")]
        public string Nazwa { get; set; }

        public ICollection<Jacht> Jachty { get; set; } = new List<Jacht>();
    }
}