using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseView
{
    public class AssociatoView
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        [Required]
        [Display(Name = "Codice Fiscale")]
        public string CodiceFiscale { get; set; }
        [Required]
        public Bajiquan.Database.Sesso Sesso { get; set; }
        public string Email { get; set; }
        [Display(Name = "Numero di Telefono")]
        public string Telefono { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataDiNascita { get; set; }

        #region Luogo di Nascita
        [Display(Name = "Luogo di Nascita : Provincia")]
        [MaxLength(2)]
        public string Nascita_Provincia { get; set; }
        [Display(Name = "Luogo di Nascita : Paese")]
        public string Nascita_Paese { get; set; }
        #endregion

        #region Residenza
        [Display(Name = "Residenza : Provincia")]
        [MaxLength(2)]
        public string Residenza_Provincia { get; set; }
        [Display(Name = "Residenza : Paese")]
        public string Residenza_Paese { get; set; }
        [Display(Name = "Residenza : Via")]
        public string Residenza_Via { get; set; }
        [Display(Name = "Residenza : Civico")]
        public string Residenza_Civico { get; set; }
        [Display(Name = "Residenza : Cap")]
        [MaxLength(5)]
        public string Residenza_Cap { get; set; }
        #endregion

    }
}
