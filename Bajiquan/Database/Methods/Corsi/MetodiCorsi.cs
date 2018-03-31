using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bajiquan.Database
{
    public partial class DB
    {
        /// <summary>
        /// Ritorna il guadagno totaleincassato per un determinato corso in un determinato corso
        /// </summary>
        /// <param name="corso">Oggetto corso per la ricerca (per ora ricerca con nome corso) </param>
        /// <param name="month">Mese per il quale ricercare gli abbonamenti</param>
        /// <returns>Se il ritorno è NULL, occorso errore durante il calcolo. Guardare LOG</returns>
        public decimal? GetGuadagnoMensileCorso(Corso corso, int month)
        {
            try
            {
                var c = Corsi.Include(a => a.Abbonamenti).Single(n => n.Nome.ToLower() == corso.Nome.ToLower());
                var money =  c.CostoMensile* c.Abbonamenti.Where(m => m.Mese.Month == month).Count();
                return money;
            }
            catch (Exception ex)
            {
                _log.WriteLog("GuadagnoMensileCorso - " +ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Ritorna il numero di iscritti attualmente al corso selezionato
        /// </summary>
        /// <param name="corso">Oggetto corso per la ricerca (per ora ricerca con nome corso) </param>
        /// <returns>Se il ritorno è NULL, occorso errore durante il calcolo. Guardare LOG</returns>
        public int? GetNuomeroIscrittiCorso(Corso corso)
        {
            try
            {
                var c = Corsi.Include(i=>i.Iscrizioni).Single(n => n.Nome.ToLower() == corso.Nome.ToLower());
                return c.Iscrizioni.Where(a=>a.Attivo).ToList().Count;
            }
            catch (Exception ex)
            {
                _log.WriteLog("GetNuomeroIscrittiCorso - " + ex.Message);
                return null;
            }

        }
    }
}
