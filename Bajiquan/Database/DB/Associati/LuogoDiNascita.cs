using System.ComponentModel.DataAnnotations;

namespace Bajiquan.Database
{
    public class LuogoDiNascita
    {
        public int Id { get; set; }
        [MaxLength(2)]
        public string Provincia { get; set; }
        public string Paese { get; set; }
    }
}
