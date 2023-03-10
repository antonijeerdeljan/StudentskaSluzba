using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Models
{
    public class StudentPPredmet
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int PredmetId { get; set; }

        public Predmet Predmet { get; set; }
    }
}
