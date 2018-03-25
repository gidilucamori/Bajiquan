namespace Bajiquan.Database
{
    public class SedeLezione
    {
        public int Id { get; set; }
        public string Provincia { get; set; }
        public string Paese { get; set; }
        public string Via { get; set; }
        public string Civico { get; set; }
        public string Cap { get; set; }
        public Lezione Lezione { get; set; }
    }



}
