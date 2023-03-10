using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Models
{
    public class PolozeniDTO
    {
        public string Sifra_predmeta { get; set; }
        public string Naziv_predmeta { get; set; }
        public int ESPB_Bodovi { get; set; }
        public int Upisana_Ocena { get; set; }
        public DateTime Datum_Polaganja { get; set; }

    }
}
