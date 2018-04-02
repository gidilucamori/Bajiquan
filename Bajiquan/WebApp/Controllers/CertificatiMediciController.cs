using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bajiquan.Database;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    public class CertificatiMediciController : Controller
    {
        private readonly Bajiquan.Database.DB _db;

        public CertificatiMediciController(Bajiquan.Database.DB db)
        {
            _db = db;
        }

        public IActionResult NuovoCertificato(DatabaseView.CertificatoMedicoView certificato, int id)
        {
            if (Request.Method == "POST" && certificato != null)
            {
                CertificatoMedico c = new CertificatoMedico()
                {
                    AssociatoId = certificato.AssociatoId,
                    DataRilascio = certificato.DataRilascio
                };

                try
                {
                    _db.CertificatiMedici.Add(c);
                    _db.SaveChanges();

                    Associato a = _db.Associati.Include(i => i.CertificatiMedici)
                        .FirstOrDefault(i=>i.Id == c.AssociatoId);

                    ViewData["SalvataggioRiuscito"] = "si";
                    ViewData["Nome"] = a.FullName;
                    ViewData["ExpityDate"] = a.CertificatiMedici.Last().DataScadenza.ToString("dd/MM/yyyy");
                    string txt = $"Grazie. Utente {a.FullName}.<br>" +
                        $"Il tuo certificato medico sarà da rifare a data {ViewData["ExpityDate"]}";

                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Length > 250)
                        ViewData["DBError"] = ex.InnerException.Message.Substring(0, 250) + " ...";
                    else ViewData["DBError"] = ex.InnerException.Message;
                }


            }

            if (Request.Method == "GET" && id != 0)
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