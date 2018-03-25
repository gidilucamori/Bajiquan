using System;

namespace Bajiquan.Database
{
    public class Abbonamento
    {
        public int Id { get; set; }
        public int CorsoId { get; set; }
        public Corso Corso { get; set; }
        public int AssociatoId { get; set; }
        public Associato Associato { get; set; }
        public DateTime Mese { get; set; }
    }



}
