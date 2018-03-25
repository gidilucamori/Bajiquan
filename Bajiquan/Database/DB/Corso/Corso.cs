using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bajiquan.Database
{
    public class Corso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Decimal CostoMensile { get; set; }
        public List<Lezione> Lezioni { get; set; }
        public List<Abbonamento> Abbonamenti { get; set; }
        public List<Iscrizione> Iscrizioni { get; set; }
    }



}
