using Domaci.cs.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaci.cs.Models;
using Domaci.cs.Models.DAOs;

namespace Domaci.cs.Controller
{
    public class ProfesorController
    {
        private readonly ProfesorDAO _profesors;
        public ProfesorController()
        {
            _profesors = new ProfesorDAO();
        }

        //FirstName,LastName, DatumRodj, AdresaStan, adresaKancelarije, Telefon, Email, brojLicne, Zvanje, godineStaza, Katedra
        public void Create(string ime, string prezime, DateTime datumRodjenja, string adresaStanovanja, string adresaKanc, string kontaktTelefon, string email, int brojLicne, string zvanje, int godineStaza, string katedra)
        {
            _profesors.Add(ime, prezime, datumRodjenja, adresaStanovanja, adresaKanc, kontaktTelefon, email, brojLicne, zvanje, godineStaza, katedra);
        }

        public void Update(string ime, string prezime, DateTime datumRodjenja, string adresaStanovanja, string adresaKanc, string kontaktTelefon, string email, int brojLicne, string zvanje, int godineStaza, string katedra, Profesor profesor)
        {
            _profesors.Update(ime, prezime, datumRodjenja, adresaStanovanja, adresaKanc, kontaktTelefon, email, brojLicne, zvanje, godineStaza, katedra, profesor);
        }


        public Profesor GetProfesorById(int? profesorId)
        {
            return _profesors.GetById(profesorId);
        }

        public List<Profesor> GetAllProfesors()
        {
            return _profesors.GetAll();
        }

        public void Delete(Profesor profesor)
        {
            _profesors.Remove(profesor);

        }

        public void Subscribe(IObserver observer)
        {
            _profesors.Subscribe(observer);
        }
    }
}