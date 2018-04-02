using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bajiquan.Database
{
    public class CertificatoMedico
    {
        public int Id { get; set; }

        public int AssociatoId { get; set; }

        public Associato Associato { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataRilascio { get; set; }

        [NotMapped]
        [DataType(DataType.Date)]
        public DateTime DataScadenza { get => DataRilascio.AddYears(1); }
    }
}
