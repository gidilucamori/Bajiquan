using System;

namespace Bajiquan.Database
{
    public class Lezione
    {
        public int Id { get; set; }
        public TimeSpan Orario { get; set; }
        public DayOfWeek Giorno { get; set; }
        public int CorsoId { get; set; }
        public Corso Corso { get; set; }
        public int SedeCorsoId { get; set; }
        public SedeLezione SedeCorso { get; set; }
    }



}
