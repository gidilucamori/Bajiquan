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
}
