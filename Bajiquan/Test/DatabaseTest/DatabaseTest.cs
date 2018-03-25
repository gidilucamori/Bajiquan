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
            //createPeople();
            //createSedeLezione();
            //createCorso();
            //createLezione();
            //createIscrizione();
            //createAbbonamento();

            getGuadagnoMensileCorso();
            getIscrittiAlCorso();
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
                Paese = "napoli"
            };
            _db.SedeCorsi.Add(x);
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
            List<Associato> a = new List<Associato>()
            {
                new Associato()
                {
                    Nome = "Luca",
                    Cognome = "Mori",
                    DataDiNascita = DateTime.Now,

                },
                new Associato()
                {
                    Nome = "Marco",
                    Cognome = "Palmisano",
                    DataDiNascita = DateTime.Now,

                },
                new Associato()
                {
                    Nome = "Ferretto",
                    Cognome = "Marrone",
                    DataDiNascita = DateTime.Now,

                },
            };
            _db.Associati.AddRange(a);
            _db.SaveChanges();
        }
    }
}
