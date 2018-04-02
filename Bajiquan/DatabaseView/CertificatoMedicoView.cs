using System;
using System.ComponentModel.DataAnnotations;
using Bajiquan.Database;

namespace DatabaseView
{
    public class CertificatoMedicoView
    {
        public int AssociatoId { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataRilascio { get; set; }
    }
}
