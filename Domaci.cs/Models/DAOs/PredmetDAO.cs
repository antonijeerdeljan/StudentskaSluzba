using Domaci.cs.Data;
using Domaci.cs.Observers;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Models.DAOs
{
    public class PredmetDAO : ISubject
    {
        private readonly List<IObserver> _observer;
        private readonly List<Predmet> _predmets;
        private readonly DataDbContext db;

        public PredmetDAO()
        {
            db = new DataDbContext();
            _predmets = new List<Predmet>();
            _predmets = db.Predmets.ToList();
            _observer = new List<IObserver>();
        }

        public Predmet createPred(int sifra, string naziv, int godinaIzvodjenja, int ESPB, int semestar)
        {
            Predmet predmet = new Predmet();
            predmet.Sifra_predmeta = sifra;
            predmet.Naziv_predmeta = naziv;
            predmet.Godina_izvodjenja_predmeta = godinaIzvodjenja;
            predmet.ESPB_Bodovi = ESPB;
            Semestar sem = (Semestar)semestar;
            predmet.Semestar = sem;
            return predmet;

        }

        public void Add(int sifra, string naziv, int godinaIzvodjenja, int ESPB, int semestar)
        {

            Predmet predmet = new Predmet();
            predmet = createPred(sifra, naziv, ESPB, godinaIzvodjenja, semestar);
            db.Predmets.Add(predmet);
            db.SaveChanges();
            NotifyObservers();


        }
        public void Update(int sifra, string naziv, int godinaIzvodjenja, int ESPB, int semestar, Predmet predmet)
        {
            int id = 0;
            Predmet tempPred = new Predmet();
            tempPred = db.Predmets.FirstOrDefault(c => c.Sifra_predmeta == predmet.Sifra_predmeta);
            id = tempPred.PredmetId;
            db.Predmets.Remove(tempPred);
            Predmet tempPred2 = new Predmet();
            tempPred2 = createPred(sifra, naziv, godinaIzvodjenja, ESPB, semestar);
            tempPred2.PredmetId = id;
            db.Predmets.Add(tempPred2);
            db.SaveChanges();
            NotifyObservers();



        }

        public void Remove(Predmet predmet)
        {
            db.Predmets.Remove(predmet);
            db.SaveChanges();
            NotifyObservers();
        }
        public List<Predmet> GetAll()
        {
            List<Predmet> std1 = db.Predmets.ToList();
            return std1;
        }

        public List<Predmet> ProfesorOpcijePredmeti(int? profesorId)
        {
            return db.Predmets.ToList().Where(predmet => predmet.ProfesorId != profesorId).ToList();
        }

        public List<Predmet> GetProfesorPredmeti(int? profesorId)
        {
            return db.Predmets.ToList().Where(predmet => predmet.ProfesorId == profesorId).ToList();
        }

        public void AddToProfesor(int? profesorId, Predmet predmet)
        {
            Predmet p = db.Predmets.ToList().First(pr => pr.PredmetId == predmet.PredmetId);
            p.ProfesorId = profesorId;
            db.SaveChanges();
            NotifyObservers();
        }

        public void RemoveFromProfesor(int? predmetId)
        {
            Predmet p = db.Predmets.ToList().First(pr => pr.PredmetId == predmetId);
            p.ProfesorId = null;
            db.SaveChanges();
            NotifyObservers();
        }

        public void removeNPPredmet(Student student, Predmet predmet)
        {
            StudentNPPredmet studentnpp = new StudentNPPredmet();
            studentnpp = db.StudentNPPredmet.FirstOrDefault(c => c.student == student && c.predmet == predmet);
            db.StudentNPPredmet.Remove(studentnpp);
            db.SaveChanges();
            NotifyObservers();
        }

        public void Subscribe(IObserver observer)
        {
            _observer.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observer.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observer)
            {
                observer.Update();
            }
        }
    }
}
