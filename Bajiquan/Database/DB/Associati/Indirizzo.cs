using System.ComponentModel.DataAnnotations;

namespace Bajiquan.Database
{
    public class Indirizzo
    {
        public int Id { get; set; }
        [MaxLength(2)]
        public string Provincia { get; set; }
        public string Paese { get; set; }
        public string Via { get; set; }
        public string Civico { get; set; }
        [MaxLength(5)]
        public string Cap { get; set; }
    }
}
