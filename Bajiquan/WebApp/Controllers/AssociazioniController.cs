using System;
using Microsoft.AspNetCore.Mvc;
using Bajiquan.Database;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    public class AssociazioniController : Controller
    {
        private readonly Bajiquan.Database.DB _db;

        public AssociazioniController(Bajiquan.Database.DB db)
        {
            _db = db;
        }

        public IActionResult NuovaAssociazione(DatabaseView.AssociazioneView associazione, int id)
        {
            if (Request.Method == "POST" && associazione != null)
            {
                Associazione a = new Associazione()
                {
                    AssociatoId = associazione.AssociatoId,
                    NumeroTessera = associazione.NumeroTessera,
                    DataRichiesta = associazione.DataRichiesta,
                    DataAccettazione = associazione.DataAccettazione,
                    DataPagamento = associazione.DataPagamento,
                    Mansione = associazione.Mansione,
                    Qualifica = associazione.Qualifica
                };

                //Controllo se l'associato ha l'iscrizione scaduta
                Associato ax = _db.Associati.Include(i => i.Associazioni).FirstOrDefault(i => i.Id == a.AssociatoId);

                //Se al giorno del pagamento l'abbonamento non è ancora scaduto
                if(ax.Associazioni.Any() && ax.Associazioni.Last().DataPagamentoExpired > a.DataPagamento)
                {
                    ViewData["AssociazioneNonScaduta"] = true;
                    ViewData["Nome"] = ax.FullName;
                    ViewData["ExpiryDate"] = ax.Associazioni.Last().DataPagamentoExpired.ToString("dd/MM/yyyy");
                }
                else
                {
                    try
                    {
                        _db.Associazioni.Add(a);
                        _db.SaveChanges();
                        ViewData["SalvataggioRiuscito"] = "si";
                        ViewData["Nome"] = ax.FullName;
                        ViewData["ExpityDate"] = ax.Associazioni.Last().DataPagamentoExpired.ToString("dd/MM/yyyy");
                        string txt = $"Grazie. Utente{ax.FullName}.<br>" +
                            $"La tua nuova iscrizione a sei armonie scadrà il gioro {ViewData["ExpityDate"]}";



                        //ViewData["CodiceFiscale"] = associato.CodiceFiscale;
                    }
                    catch (Exception ex)
                    {
                        if (ex.InnerException.Message.Length > 250)
                            ViewData["DBError"] = ex.InnerException.Message.Substring(0, 250) + " ...";
                        else ViewData["DBError"] = ex.InnerException.Message;
                    }
                }
                
            }

            if(Request.Method == "GET" && id != 0)
            {
                ViewData["AssociatoRichiesto"] = id;
            }

            List<ShortInfo> l = new List<ShortInfo>();
            foreach (var socio in _db.Associati.ToList())
            {
                l.Add(new ShortInfo(socio.Id, socio.FullName));
            }
            SelectAssociato s = new SelectAssociato()
            {
                Id = -1,
                Elenco = l
            };
            ViewData["ListOfAssociati"] = s;
            return View();
        }
    }
}