using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Models
{
    public class StudentPredmet
    {
        public int StudentId { get; set; }
        public Student student { get; set; }
        public int PredmetId { get; set; }
        public Predmet predmet { get; set; }
    }
}
