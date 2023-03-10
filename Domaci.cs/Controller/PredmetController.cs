using Domaci.cs.Models;
using Domaci.cs.Models.DAOs;
using Domaci.cs.Observers;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Controller
{
    public class PredmetController
    {
        private readonly PredmetDAO _predmeti;
        public PredmetController()
        {
            _predmeti = new PredmetDAO();
        }

        public void Create(int Sifra, string naziv, int espBodovi, int godinaIzvodjenja, int semestarIzvodjenja)
        {
            _predmeti.Add(Sifra, naziv, espBodovi, godinaIzvodjenja, semestarIzvodjenja);
        }

        public void Update(int Sifra, string naziv, int espBodovi, int godinaIzvodjenja, int semestarIzvodjenja, Predmet predmet)
        {
            _predmeti.Update(Sifra, naziv, espBodovi, godinaIzvodjenja, semestarIzvodjenja, predmet);
        }

        public List<Predmet> GetAllPredmet()
        {
            return _predmeti.GetAll();
        }

        public List<Predmet> GetAllProfesorOpcijePredmeti(int? profesorId)
        {
            return _predmeti.ProfesorOpcijePredmeti(profesorId);
        }

        public List<Predmet> GetAllProfesorPredmeti(int? profesorId)
        {
            return _predmeti.GetProfesorPredmeti(profesorId);
        }


        public void AddPredmetToProfesor(int? profesorId, Predmet predmet)
        {
            _predmeti.AddToProfesor(profesorId, predmet);
        }

        public void DeleteProfesorFromPredmet(int? predmetId)
        {
            _predmeti.RemoveFromProfesor(predmetId);
        }

        public void removeNPPredmet(Student student, Predmet predmet)
        {
            _predmeti.removeNPPredmet(student, predmet);
        }


        public void Delete(Predmet predmet)
        {
            _predmeti.Remove(predmet);

        }

        public void Subscribe(IObserver observer)
        {
            _predmeti.Subscribe(observer);
        }
    }
}
