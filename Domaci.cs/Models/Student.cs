using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Models
{
    public enum Status
    {
        B = 0, //Budzet
        S = 1 //Samofinansiranje
    }
    public class Student
    {
        public int StudentId { get; set; }
        public string Prezime { get; set; }
        public string Sifra { get; set; }
        public string TempPassword { get; set; } = string.Empty;
        public string Ime { get; set; }
        public DateTime Datum_Rodjenja { get; set; }

        public Adresa Adresa { get; set; }

        public int IDAdresa { get; set; }
        public string Kontakt_Telefon { get; set; }
        public string E_Mail { get; set; }
        public string Broj_Indeksa { get; set; }
        public int Godina_Upisa { get; set; }
        public int Trenunta_Godina { get; set; }

        public Status Status { get; set; }

        public ICollection<StudentPPredmet> PPredmet { get; set; }

        public ICollection<StudentNPPredmet> NPredmet { get; set; }

        public ICollection<StudentPredmet> slusaPredmete { get; set; } //da li se tu vec nalaze nepolozeni predmeti?

        public double? Prosecna_Ocena { get; set; } //napravi na osnovu ocena koje student vec ima

        public ICollection<Ocena> Ocene { get; set; }


        //public List<Ocena> Spisak_Polozenih_Ispita { get; set; }
        //public List<Ocena> Spisak_Nepolozenih_Ispita { get; set; }
    }
}
