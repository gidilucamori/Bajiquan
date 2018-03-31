using System;

namespace DatabaseView
{
    public class Associato
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public string Email { get; set; }
        public DateTime DataDiNascita { get; set; }
        public int LuogoNascitaId { get; set; }

        #region Luogo di Nascita
        public string Nascita_Provincia { get; set; }
        public string Nascita_Paese { get; set; }
        public string Nascita_Via { get; set; }
        public string Nascita_Civico { get; set; }
        public string Nascita_Cap { get; set; }
        #endregion

        #region Residenza
        public string Residenza_Provincia { get; set; }
        public string Residenza_Paese { get; set; }
        public string Residenza_Via { get; set; }
        public string Residenza_Civico { get; set; }
        public string Residenza_Cap { get; set; }
        #endregion

    }
}
