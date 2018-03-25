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
    }
}
