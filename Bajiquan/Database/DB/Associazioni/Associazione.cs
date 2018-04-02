using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bajiquan.Database
{
    public class Associazione
    {
        public int Id { get; set; }
        public int AssociatoId { get; set; }
        public string NumeroTessera { get; set; }
        public Associato Associato { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataRichiesta { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataAccettazione { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataPagamento { get; set; }

        [DataType(DataType.Date)]
        [NotMapped]
        public DateTime DataPagamentoExpired { get => DataPagamento.AddYears(1); } 

        public Mansione Mansione { get; set; }
        public Qualifica Qualifica { get; set; }
    }
 }
