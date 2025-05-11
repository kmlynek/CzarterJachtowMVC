using Firma.Data.Data.Flota;
using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Data.Rezerwacje
{
    public class Rezerwacja
    {
        [Key]
        public int IdRezerwacji { get; set; }

        [Required]
        [Display(Name = "Data od")]
        public DateTime DataOd { get; set; }

        [Required]
        [Display(Name = "Data do")]
        public DateTime DataDo { get; set; }

        [Display(Name = "Jacht")]
        public int IdJachtu { get; set; }
        public Jacht? Jacht { get; set; }

        [Display(Name = "Klient")]
        public int IdKlienta { get; set; }
        public Klient? Klient { get; set; }
    }
}