using Firma.Data.Data.Rezerwacje;
using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Data.Rezerwacje
{
    public class Klient
    {
        [Key]
        public int IdKlienta { get; set; }

        [Required]
        [Display(Name = "Imię")]
        public string Imie { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }

        [Required, EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public ICollection<Rezerwacja> Rezerwacje { get; set; } = new List<Rezerwacja>();
    }
}