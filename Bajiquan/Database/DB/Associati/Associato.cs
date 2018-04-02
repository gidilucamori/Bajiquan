using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bajiquan.Database
{
    public class Associato
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cognome { get; set; }

        [NotMapped]
        public string FullName { get => Nome + " " + Cognome; }

        [Required]
        public string CodiceFiscale { get; set; }

        [Required]
        public Sesso Sesso { get; set; }

        public string Telefono { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataDiNascita { get; set; }

        public List<Associazione> Associazioni { get; set; }
        public List<CertificatoMedico> CertificatiMedici { get; set; }

        //Sono impostati nullable perchè cosi posso creare un associato ma
        //impostare in un secondo momento il luogo di nascita e il domicilio
        public int? LuogoDiNascitaId { get; set; }
        public LuogoDiNascita LuogoDiNascita { get; set; }

        public int? ResidenzaId { get; set; }
        public Indirizzo Residenza { get; set; }
    }



    public class ShortInfo
    {
        public ShortInfo(int id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }
        public int Id { get; }
        public string FullName { get; }
    }

    public class SelectAssociato
    {
        public int Id { get; set; }
        public List<ShortInfo> Elenco { get; set; }
    }
}
