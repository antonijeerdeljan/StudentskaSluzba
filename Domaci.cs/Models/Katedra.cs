using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Models
{
    public class Katedra
    {
        public int KatedraId { get; set; }
        public int Sifra_Katedre { get; set; } // id za katedru

        public string Naziv_Katedre { get; set; }

        public int? sefKatedreId { get; set; } // broj licne karte profesora kao ID

        public List<Profesor> profNaKatedri { get; set; }

    }
}
