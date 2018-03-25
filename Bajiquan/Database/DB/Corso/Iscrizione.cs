using System;
using System.Collections.Generic;
using System.Text;

namespace Bajiquan.Database
{
    public class Iscrizione
    {
        public int Id { get; set; }
        public int AssociatoId { get; set; }
        public Associato Associato { get; set; }
        public int CorsoId { get; set; }
        public Corso Corso { get; set; }
        public bool Attivo { get; set; }
    }
}
