using Domaci.cs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Models.DAOs
{
    public class OcenaDAO
    {
        private readonly List<Ocena> _ocenas;
        private readonly DataDbContext db;

        public OcenaDAO()
        {
            db = new DataDbContext();
            _ocenas = new List<Ocena>();
            _ocenas = db.Ocenas.ToList();
        }

        public void Add(Student student, Predmet predmet, int upisanaOcena, DateTime datumPolaganja)
        {
            Ocena ocena = new Ocena();
            //kasnije implementirati automapper
            ocena.Student = student;
            ocena.Predmet = predmet;
            ocena.Upisana_Ocena = upisanaOcena;
            ocena.Datum_Polaganja = datumPolaganja;
            db.Ocenas.Add(ocena);
            db.SaveChanges();
        }

        public void Remove(Ocena ocena)
        {
            _ocenas.Remove(ocena);
            db.SaveChanges();
        }
        public List<Ocena> GetAll()
        {
            return _ocenas;
        }
    }
}
