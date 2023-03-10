using Domaci.cs.Data;
using Domaci.cs.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaci.cs.Observers;


namespace Domaci.cs.Models.DAOs
{
    public class ProfesorDAO : ISubject
    {

        private readonly List<IObserver> _observers;
        private readonly List<Profesor> _profesors;
        private readonly DataDbContext db;

        public ProfesorDAO()
        {
            db = new DataDbContext();
            _profesors = new List<Profesor>();
            _profesors = db.Profesors.ToList();
            _observers = new List<IObserver>();
        }


        //_profesors.Add(ime, prezime, datumRodjenja, adresaStanovanja, adresaKanc, kontaktTelefon, email, brojLicne, zvanje, godineStaza, katedra);
        public Profesor createProf(string Ime, string Prezime, DateTime datumRodjenja, string adresaStanovanja, string adresaKancelarije, string kontaktTelefon, string email, int brojLicne, string zvanje, int godineStaza, string katedra)
        {
            Profesor profesor = new Profesor();
            List<string> adresaTemp1 = adresaStanovanja.Split(',').ToList<string>();
            List<string> adresaTemp2 = adresaKancelarije.Split(',').ToList<string>();

            Adresa adr1 = new Adresa();
            Adresa adr2 = new Adresa();

            adr1.Drzava = adresaTemp1[0];
            adr1.Grad = adresaTemp1[1];
            adr1.Ulica = adresaTemp1[2];
            adr1.Broj = adresaTemp1[3];

            adr2.Drzava = adresaTemp2[0];
            adr2.Grad = adresaTemp2[1];
            adr2.Ulica = adresaTemp2[2];
            adr2.Broj = adresaTemp2[3];

            //kasnije implementirati automapper
            profesor.Prezime = Prezime;
            profesor.Ime = Ime;
            profesor.Datum_Rodjenja = datumRodjenja;
            profesor.adresa_stanovanja = adr1;
            profesor.adresa_kancelarije = adr2;
            profesor.Kontakt_Telefon = kontaktTelefon;
            profesor.E_Mail = email;
            profesor.Broj_Licne = brojLicne;
            profesor.Zvanje = zvanje;
            profesor.Godine_Staza = godineStaza;
            Katedra tempKatedra = new Katedra();
            tempKatedra.Naziv_Katedre = katedra;

            Katedra katedra1 = new Katedra();

            if (katedra != null)
            {
                katedra1 = db.Katedras.FirstOrDefault(c => c.Naziv_Katedre == katedra);
                profesor.KatedraID = katedra1.KatedraId;
                profesor.katedra = katedra1;
            }
            else
            {
                profesor.KatedraID = null;

            }
            return profesor;
        }

        public void Add(string Ime, string Prezime, DateTime datumRodjenja, string adresaStanovanja, string adresaKancelarije, string kontaktTelefon, string email, int brojLicne, string zvanje, int godineStaza, string katedra)
        {
            Profesor profesor = new Profesor();

            profesor = createProf(Ime, Prezime, datumRodjenja, adresaStanovanja, adresaKancelarije, kontaktTelefon, email, brojLicne, zvanje, godineStaza, katedra);


            db.Profesors.Add(profesor);
            db.SaveChanges();
            NotifyObservers();

        }




        public void Update(string Ime, string Prezime, DateTime datumRodjenja, string adresaStanovanja, string adresaKancelarije, string kontaktTelefon, string email, int brojLicne, string zvanje, int godineStaza, string katedra, Profesor profesor)

        {
            int Id = 0;
            Profesor tempProf = new Profesor();
            tempProf = db.Profesors.FirstOrDefault(c => c.ProfesorId == profesor.ProfesorId);
            Id = (int)tempProf.ProfesorId;
            db.Profesors.Remove(tempProf);
            Profesor tempProf2 = new Profesor();
            tempProf2 = createProf(Ime, Prezime, datumRodjenja, adresaStanovanja, adresaKancelarije, kontaktTelefon, email, brojLicne, zvanje, godineStaza, katedra);
            tempProf2.ProfesorId = Id;
            db.Profesors.Add(tempProf2);
            db.SaveChanges();
            NotifyObservers();
        }



        public void Remove(Profesor profesor)
        {
            db.Profesors.Remove(profesor);
            db.SaveChanges();
            NotifyObservers();
        }
        public List<Profesor> GetAll()
        {
            List<Profesor> prf = db.Profesors.ToList();
            return prf;
        }

        public Profesor GetById(int? profesorId)
        {
            return db.Profesors.First(profesor => profesor.ProfesorId == profesorId);
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
}
