using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bajiquan.Database
{
    public class DatabaseTest
    {
        private readonly DB _db;

        public DatabaseTest(DB db)
        {
            _db = db;
        }

        public void Start()
        {
            //testAddress();
            //testAssociatoView();
            //createPeople();
            //createSedeLezione();
            //createCorso();
            //createLezione();
            //createIscrizione();
            //createAbbonamento();
            //testAssociazione();
            //getGuadagnoMensileCorso();
            //getIscrittiAlCorso();
            ricreateTestDB();
        }

        private void ricreateTestDB()
        {
            createPeople();

        }

        private void testAssociazione()
        {
            Associazione a = new Associazione()
            {
                Qualifica = Qualifica.SocioOrdinario,
                Mansione = Mansione.Allievo,
                DataRichiesta = DateTime.Now,
                DataAccettazione = DateTime.Now,
                DataPagamento = DateTime.Now,
                AssociatoId = 1
            };
            _db.Associazioni.Add(a);
            _db.SaveChanges();

            Associato x = _db.Associati.Include(i => i.Associazioni).FirstOrDefault(i=>i.Id == 1);
            _db.SaveChanges();
            Associato f = _db.Associati.Include(i => i.Associazioni).FirstOrDefault(i => i.Id == 1);
        }

        private void testAssociatoView()
        {
            //test database
            DatabaseView.AssociatoView associatoView = new DatabaseView.AssociatoView()
            {
                Nome = "Luca",
                Cognome = "Mori",
                CodiceFiscale = "qwe",
                Email = "pongo.ot",
                Nascita_Paese = "Saronno",
                Nascita_Provincia = "VA",
                Sesso = Sesso.Maschio,
                Telefono = "029692728",
                DataDiNascita = DateTime.Parse("1990/11/05"),
                Residenza_Provincia = "MI",
                Residenza_Cap = "20020",
                Residenza_Civico = "3/50",
                Residenza_Paese = "Solaro",
                Residenza_Via = "G.Giusti"

            };


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

        private void testAddress()
        {
            Database.Indirizzo i = new Indirizzo()
            {
                Cap = "20020",
                Civico = "3/50",
                Paese = "Solaro",
                Provincia = "MI",
                Via = "G.Giusti"
            };
            _db.GetOrCreateResidenza(i);
        }

        private void getGuadagnoMensileCorso()
        {
            Console.WriteLine(_db.GetGuadagnoMensileCorso(new Corso() { Nome = "Baji" }, 1));
        }

        private void getIscrittiAlCorso()
        {
            Console.WriteLine(_db.GetNuomeroIscrittiCorso(new Corso() { Nome = "Baji" }));
        }

        private void createIscrizione()
        {
            List<Iscrizione> i = new List<Iscrizione>()
            {
                new Iscrizione()
                {
                    AssociatoId = 1,
                    Attivo = true,
                    CorsoId = 1
                },
                new Iscrizione()
                {
                    AssociatoId = 2,
                    Attivo = true,
                    CorsoId = 1
                },
                new Iscrizione()
                {
                    AssociatoId = 3,
                    Attivo = true,
                    CorsoId = 1
                },
            };

            _db.Iscrizioni.AddRange(i);
            _db.SaveChanges();
        }

        private void createCorso()
        {
            List<Corso> corsi = new List<Corso>()
            {
                new Corso()
                {
                    Nome = "Baji",
                    CostoMensile = 45,
                },
                new Corso()
                {
                    Nome = "Shaolin",
                    CostoMensile = 45
                },
                new Corso()
                {
                    Nome = "Sci",
                    CostoMensile = 45
                },
             };
            _db.Corsi.AddRange(corsi);
            _db.SaveChanges();
        }

        private void createAbbonamento()
        {
            List<Abbonamento> x = new List<Abbonamento>()
            {
                 new Abbonamento()
                 {
                    AssociatoId = 1,
                    CorsoId = 1,
                    Mese = new DateTime(DateTime.Now.Year, 1, 1)
                 },
                 new Abbonamento()
                 {
                    AssociatoId = 1,
                    CorsoId = 1,
                    Mese = new DateTime(DateTime.Now.Year, 2, 1)
                 },
                 new Abbonamento()
                 {
                    AssociatoId = 1,
                    CorsoId = 1,
                    Mese = new DateTime(DateTime.Now.Year, 3, 1)
                 },
                 new Abbonamento()
                 {
                    AssociatoId = 2,
                    CorsoId = 1,
                    Mese = new DateTime(DateTime.Now.Year, 1, 1)
                 },
                 new Abbonamento()
                 {
                    AssociatoId = 2,
                    CorsoId = 1,
                    Mese = new DateTime(DateTime.Now.Year, 2, 1)
                 },
                 new Abbonamento()
                 {
                    AssociatoId = 2,
                    CorsoId = 1,
                    Mese = new DateTime(DateTime.Now.Year, 3, 1)
                 },
                 new Abbonamento()
                 {
                    AssociatoId = 3,
                    CorsoId = 1,
                    Mese = new DateTime(DateTime.Now.Year, 1, 1)
                 },
            };

            _db.Abbonamenti.AddRange(x);
            _db.SaveChanges();
        }

        private void createSedeLezione()
        {
            SedeLezione x = new SedeLezione()
            {
                Indirizzo = new Indirizzo()
                {
                    Paese = "napoli",
                    Cap = "20320",
                    Civico = "3a",
                    Provincia = "Cesenatico",
                    Via = "Del tutto eccezionale"
                }

            };
            _db.SedeLezioni.Add(x);
            _db.SaveChanges();
        }

        private void createLezione()
        {
            Lezione l = new Lezione()
            {
                CorsoId = 1,
                Orario = new TimeSpan(23, 0, 0),
                SedeCorsoId = 1
            };
            _db.Lezioni.Add(l);
            _db.SaveChanges();
        }

        private void createPeople()
        {

            LuogoDiNascita LuogoNascita = new LuogoDiNascita()
            {
                Paese = "Solaro",
                Provincia = "MI",
            };
            _db.LuoghiDiNascita.Add(LuogoNascita);
            _db.SaveChanges();

            List<Associato> a = new List<Associato>()
            {

                new Associato()
                {
                    Nome = "Luca",
                    Cognome = "Mori",
                    DataDiNascita = DateTime.Now,
                    CodiceFiscale = "MROLCU",
                    Email = "luca.mori@hotmail.it",
                    Sesso = Sesso.Maschio,
                    Telefono = "029692728",
                    LuogoDiNascitaId = 1
                },
                new Associato()
                {
                    Nome = "Luca",
                    Cognome = "Mori",
                    DataDiNascita = DateTime.Now,
                    CodiceFiscale = "MROLCUW",
                    Email = "luca.mori@hotmail.it",
                    Sesso = Sesso.Maschio,
                    Telefono = "029692728",
                    LuogoDiNascitaId = 1
                },
                new Associato()
                {
                    Nome = "Luca",
                    Cognome = "Mori",
                    DataDiNascita = DateTime.Now,
                    CodiceFiscale = "MROLCUD",
                    Email = "luca.mori@hotmail.it",
                    Sesso = Sesso.Maschio,
                    Telefono = "029692728",
                    LuogoDiNascitaId = 1
                },
            };
            _db.Associati.AddRange(a);
            _db.SaveChanges();
        }
    }
}
