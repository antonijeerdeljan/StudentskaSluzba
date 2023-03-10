using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Models
{
    public class Adresa
    {
        public int AdresaId { get; set; }
        public string Ulica { get; set; }
        public string Broj { get; set; }
        public string Grad { get; set; }
        public string Drzava { get; set; }

        public ICollection<Student> Studenti { get; set; }
        public ICollection<Profesor> ProfesoriKuca { get; set; }
        public ICollection<Profesor> ProfesoriKanc { get; set; }

    }
}
