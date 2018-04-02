using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bajiquan.Database;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    public class AssociatiController : Controller
    {
        private readonly Bajiquan.Database.DB _db;

        public AssociatiController(Bajiquan.Database.DB db)
        {
            _db = db;
        }

        public IActionResult NuovoAssociato(DatabaseView.AssociatoView associatoView)
        {
            if (Request.Method == "POST" && associatoView != null)
            {
                LuogoDiNascita luogoDiNascita = new LuogoDiNascita()
                {
                    Paese = associatoView.Nascita_Paese,
                    Provincia = associatoView.Nascita_Provincia,
                };

                Indirizzo residenza = new Indirizzo()
                {
                    Cap = associatoView.Residenza_Cap,
                    Civico = associatoView.Residenza_Civico,
                    Paese = associatoView.Residenza_Paese,
                    Provincia = associatoView.Residenza_Provincia,
                    Via = associatoView.Residenza_Via
                };

                Associato associato = new Associato()
                {
                    CodiceFiscale = associatoView.CodiceFiscale,
                    Sesso = associatoView.Sesso,
                    Nome = associatoView.Nome,
                    Cognome = associatoView.Cognome,
                    DataDiNascita = associatoView.DataDiNascita,
                    Email = associatoView.Email,
                    Telefono = associatoView.Telefono,
                    LuogoDiNascitaId = _db.GetOrCreateLuogoDiNascita(luogoDiNascita),
                    ResidenzaId = _db.GetOrCreateResidenza(residenza)
                };

                try
                {
                    _db.Associati.Add(associato);
                    _db.SaveChanges();
                    ViewData["SalvataggioRiuscito"] = "si";
                    ViewData["Nome"] = associato.FullName;
                    ViewData["CodiceFiscale"] = associato.CodiceFiscale;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Length > 250)
                        ViewData["DBError"] = ex.InnerException.Message.Substring(0, 250) + " ...";
                    else ViewData["DBError"] = ex.InnerException.Message;
                }
            }
            return View();
        }

        public IActionResult Elenco(string search)
        {
            List<Associato> l = new List<Associato>();
            if (Request.Method == "POST" && search != null)
            {
                search = search.Trim();
                l = _db.Associati.Include(i => i.Associazioni).Include(i => i.CertificatiMedici)
                    .Where(i => i.Nome.Contains(search) || i.Cognome.Contains(search)).ToList();
                ViewData["Searched"] = true;
                ViewData["txt"] = search;
            }
            else
            {
                l = _db.Associati.Include(i => i.Associazioni).Include(i => i.CertificatiMedici).ToList();
            }
            return View(l);
        }

        public IActionResult Modifica(Associato associato, int id)
        {
            if (Request.Method == "POST" && associato != null)
            {
                //LuogoDiNascita luogoDiNascita = new LuogoDiNascita()
                //{
                //    Paese = associato.Nascita_Paese,
                //    Provincia = associato.Nascita_Provincia,
                //};

                //Indirizzo residenza = new Indirizzo()
                //{
                //    Cap = associatoView.Residenza_Cap,
                //    Civico = associatoView.Residenza_Civico,
                //    Paese = associatoView.Residenza_Paese,
                //    Provincia = associatoView.Residenza_Provincia,
                //    Via = associatoView.Residenza_Via
                //};

                Associato a = _db.Associati.Include(i => i.Residenza).Include(i => i.LuogoDiNascita)
                    .FirstOrDefault(i => i.Id == 1);

                a.CodiceFiscale = associato.CodiceFiscale;
                a.Sesso = associato.Sesso;
                a.Nome = associato.Nome;
                a.Cognome = associato.Cognome;
                a.DataDiNascita = associato.DataDiNascita;
                a.Email = associato.Email;
                a.Telefono = associato.Telefono;
                //a.LuogoDiNascitaId = _db.GetOrCreateLuogoDiNascita(luogoDiNascita);
                //a.ResidenzaId = _db.GetOrCreateResidenza(residenza);

                try
                {
                    _db.SaveChanges();
                    ViewData["SalvataggioRiuscito"] = "si";
                    ViewData["Nome"] = associato.FullName;
                    ViewData["CodiceFiscale"] = associato.CodiceFiscale;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Length > 250)
                        ViewData["DBError"] = ex.InnerException.Message.Substring(0, 250) + " ...";
                    else ViewData["DBError"] = ex.InnerException.Message;
                }
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