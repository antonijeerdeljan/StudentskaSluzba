using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Models
{
    public enum Semestar
    {
        L = 0,//Letnji
        Z = 1// Zimski
    }
    public class Predmet
    {
        public int PredmetId { get; set; }
        public int Sifra_predmeta { get; set; }

        public string Naziv_predmeta { get; set; }

        public int Godina_izvodjenja_predmeta { get; set; }

        public Profesor profesorPredaje { get; set; }

        public int? ProfesorId { get; set; }

        public int ESPB_Bodovi { get; set; }

        public Semestar Semestar { get; set; }
        public ICollection<StudentPredmet> sviSudenti { get; set; }

        public ICollection<StudentPPredmet> StudentP { get; set; }// Studenti koji su polozili //Treba promenni 1:m

        public ICollection<StudentNPPredmet> StudentNP { get; set; } //Studenti koji nisu polozili 1:m

    }
}
