using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Models
{
    public class Profesor
    {
        public int? ProfesorId { get; set; }
        public string Prezime { get; set; }
        public string Ime { get; set; }
        public DateTime Datum_Rodjenja { get; set; }


        public Adresa adresa_stanovanja { get; set; }
        public int adresaStanovanjaID { get; set; }
        public Adresa adresa_kancelarije { get; set; }
        public int adresaKancelarijeID { get; set; }


        public string Kontakt_Telefon { get; set; }
        public string E_Mail { get; set; }
        public int Broj_Licne { get; set; }
        public string Zvanje { get; set; }
        public int Godine_Staza { get; set; }

        public int? KatedraID { get; set; }

        public Katedra? katedra { get; set; }

        public List<Predmet> predajePredmeti { get; set; }
    }
}
