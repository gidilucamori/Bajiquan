using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatabaseView
{
    public class AssociazioneView
    {
        [Required]
        public int AssociatoId { get; set; }

        [Required]
        [Display(Name = "Numero Tessera")]
        public string NumeroTessera { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataRichiesta { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataAccettazione { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataPagamento { get; set; }

        public Bajiquan.Database.Mansione Mansione { get; set; }

        public Bajiquan.Database.Qualifica Qualifica { get; set; }
    }
}
