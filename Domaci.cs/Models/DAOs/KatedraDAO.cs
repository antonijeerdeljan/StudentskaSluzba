using Domaci.cs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Models.DAOs
{
    public class KatedraDAO
    {
        private readonly List<Katedra> _katedras;
        private readonly DataDbContext db;

        public KatedraDAO()
        {
            db = new DataDbContext();
            _katedras = new List<Katedra>();
            _katedras = db.Katedras.ToList();
        }




        public void createKatedra(int sifra, string naziv, string sef)
        {
            Katedra kat = new Katedra();
            kat.Naziv_Katedre = naziv;
            kat.Sifra_Katedre = sifra;
            Profesor sefprof = new Profesor();
            if (sef != null)
            {
                sefprof = findProfesor(sef);
                kat.sefKatedreId = (int)sefprof.ProfesorId;
            }
            else
            {
                kat.sefKatedreId = null;
            }
            db.Katedras.Add(kat);
            db.SaveChanges();
        }

        public void setSefKatedre(Katedra ktd, string sef)
        {
            Profesor prof = findProfesor(sef);
            Katedra katedranew = new Katedra();
            Katedra oldktd = new Katedra();

            katedranew = ktd;
            katedranew.sefKatedreId = prof.ProfesorId;

            oldktd = db.Katedras.FirstOrDefault(c => c.Sifra_Katedre == ktd.Sifra_Katedre && c.Naziv_Katedre == ktd.Naziv_Katedre);

            db.Katedras.Remove(oldktd);
            db.Katedras.Add(katedranew);
            db.SaveChanges();
        }

        public Profesor findProfesor(string sef)
        {
            Profesor profesor = new Profesor();
            List<String> lista = new List<String>();
            lista = sef.Split(' ').ToList<string>();
            int licna = Int32.Parse(lista[0]);


            profesor = db.Profesors.FirstOrDefault(c => c.Broj_Licne == licna);
            return profesor;


        }



        /*public void Add(int sifraKatedre, string nazivKatedre, int sefKatedreId)
        {
            Katedra katedra = new Katedra();
            //kasnije implementirati automapper
            katedra.Sifra_Katedre = sifraKatedre;
            katedra.Naziv_Katedre = nazivKatedre;
            katedra.sefKatedreId = sefKatedreId;
            db.Katedras.Add(katedra);
            db.SaveChanges();
        }*/

        public void Remove(Katedra katedra)
        {
            _katedras.Remove(katedra);
            db.SaveChanges();
        }
        public List<Katedra> GetAll()
        {
            List<Katedra> katedre = new List<Katedra>();
            katedre = db.Katedras.ToList();
            return katedre;
        }
    }
}
