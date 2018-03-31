using System;
using System.Collections.Generic;
using System.Text;

namespace Bajiquan.Database
{
    public class Associato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public string Email { get; set; }
        public DateTime DataDiNascita { get; set; }
        public int LuogoNascitaId { get; set; }
        public Indirizzo LuogoNascita { get; set; }
        //public int ResidenzaId { get; set; }
        //public Indirizzo Residenza { get; set; }
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

}
