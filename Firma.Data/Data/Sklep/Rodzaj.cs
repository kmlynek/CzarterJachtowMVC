﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.Sklep
{
    public class Rodzaj
    {
        [Key]
        public int IdRodzaju { get; set; }

        [Required(ErrorMessage = "Podaj nazwę rodzaju")]
        [MaxLength(30, ErrorMessage = "Nazwa kategori powinna mieć max 30 znaków")]
        public required string Nazwa { get; set; }

        public string Opis { get; set; } = string.Empty;
        public ICollection<Towar> Towar { get; } = new List<Towar>();
    }
}
