using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bajiquan.Database
{
    public partial class DB : DbContext
    {
        //classe Log, per loggare sulla macchina tutti gli errori compiuti con l'interazione del database.
        private Luca.Logger _log = new Luca.Logger(@"\Bajiquan\Database");

        public DbSet<Associato> Associati { get; set; }
        public DbSet<Corso> Corsi { get; set; }
        public DbSet<Lezione> Lezioni { get; set; }
        public DbSet<SedeLezione> SedeLezioni { get; set; }
        public DbSet<Abbonamento> Abbonamenti { get; set; }
        public DbSet<Iscrizione> Iscrizioni { get; set; }

        public DB(DbContextOptions<DB> options) : base(options)
        {
            //Database.EnsureDeleted();// Se esiste elimina il database
            Database.EnsureCreated();// Crea il database se non esiste

        }
        public DB()
        {
            //Database.EnsureDeleted();// Se esiste elimina il database
            Database.EnsureCreated();// Crea il database se non esiste

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Associati
            //Tabella associati, codice fiscale non puo essere dupplicato
            modelBuilder.Entity<Associato>()
                .HasIndex(i => new { i.CodiceFiscale})
                .IsUnique();
            #endregion

            #region Iscrizioni corsi
            //Una persona puo iscriversi ad un corso una sola volta
            modelBuilder.Entity<Iscrizione>()
                .HasIndex(i => new { i.AssociatoId, i.CorsoId})
                .IsUnique();
            #endregion

            #region Abbonamenti mensili
            //Abbonamenti non possono essere dello stesso mese e della stessa persona per lo stesso corso
            modelBuilder.Entity<Abbonamento>()
                .HasIndex(i => new { i.AssociatoId, i.CorsoId, i.Mese })
                .IsUnique();
            #endregion

            #region Corsi sportivi
            //I corsi sportivi non possono essere registrati con lo stesso nome
            modelBuilder.Entity<Corso>()
                .HasIndex(i => new { i.Nome })
                .IsUnique();
            #endregion

            #region Lezioni corsi
            //Le lezioni non possono avere stesso corso, giorno, ora e sede
            modelBuilder.Entity<Lezione>()
                .HasIndex(i => new { i.CorsoId, i.Giorno, i.Orario, i.SedeCorsoId })
                .IsUnique();
            #endregion

            #region Sede Lezioni
            //Le lezioni non possono avere stesso corso, giorno, ora e sede
            modelBuilder.Entity<SedeLezione>()
                .HasIndex(i => new { i.Provincia, i.Paese, i.Via, i.Civico })
                .IsUnique();
            #endregion

        }
    }
}
