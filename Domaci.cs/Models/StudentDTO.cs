using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Models
{
    public class StudentDTO
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string DatumRodj { get; set; }

        public string AdresaStan { get; set; }
        public string BrojTel { get; set; }
        public string Email { get; set; }
        public string BrojIndeksa { get; set; }
        public string GodinaUpisa { get; set; }
        public string TrenuntaGodina { get; set; }

        public string Status { get; set; }
    }
}
