using Firma.Data.Data.Flota;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Data.Flota
{
    public class Jacht
    {
        [Key]
        public int IdJachtu { get; set; }

        [Required]
        [Display(Name = "Nazwa jachtu")]
        public string? Nazwa { get; set; }

        [Display(Name = "Rok budowy")]
        public int RokBudowy { get; set; }

        [Display(Name = "Cena za dzień (PLN)")]
        public decimal CenaZaDzien { get; set; }

        [Display(Name = "Opis jachtu")]
        public string? Opis { get; set; }

        [Display(Name = "Kategoria jachtu")]
        public int IdKategorii { get; set; }

        [ForeignKey("IdKategorii")]
        public KategoriaJachtu? KategoriaJachtu { get; set; }

        [Display(Name = "Port bazowy")]
        public int IdPortu { get; set; }

        [ForeignKey("IdPortu")]
        public Port? Port { get; set; }

        public ICollection<ZdjecieJachtu> Zdjecia { get; set; } = new List<ZdjecieJachtu>();
    }
}