using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bajiquan.Database
{
    public class Associato
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        [Required]
        public string CodiceFiscale { get; set; }
        [Required]
        public Sesso Sesso { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataDiNascita { get; set; }
        public int? LuogoDiNascitaId { get; set; }
        public LuogoDiNascita LuogoDiNascita { get; set; }
        public int? ResidenzaId { get; set; }
        public Indirizzo Residenza { get; set; }
    }

    public enum Sesso
    {
        Mashcio,
        Femmina
    }

    public class Indirizzo
    {
        public int Id { get; set; }
        public string Provincia { get; set; }
        public string Paese { get; set; }
        public string Via { get; set; }
        public string Civico { get; set; }
        public string Cap { get; set; }
    }

    public class LuogoDiNascita
    {
        public int Id { get; set; }
        public string Provincia { get; set; }
        public string Paese { get; set; }
    }
}
