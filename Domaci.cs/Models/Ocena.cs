using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Models
{
    public class Ocena
    {
        public int OcenaId { get; set; } //specificna ocena sa speficicnog studenta

        public Student Student { get; set; }
        //public Student StudentId { get; set; } //id za sifru studenta

        public Predmet Predmet { get; set; }
        //public Predmet PredmetId { get; set; } //id za sifru predmeta

        public int Upisana_Ocena { get; set; }

        public DateTime Datum_Polaganja { get; set; }

    }
}
