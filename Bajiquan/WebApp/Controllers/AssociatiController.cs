using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bajiquan.Database;

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

                _db.Associati.Add(associato);
                _db.SaveChanges();
            }
            return View();
        }
    }
}