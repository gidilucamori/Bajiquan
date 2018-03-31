namespace Bajiquan.Database
{
    public class SedeLezione
    {
        public int Id { get; set; }
        public int IndirizzoId { get; set; }
        public Indirizzo Indirizzo { get; set; }
        public Lezione Lezione { get; set; }
    }



}
