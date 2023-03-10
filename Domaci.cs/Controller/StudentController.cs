using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaci.cs.Observers;
using Domaci.cs.Models;
using Domaci.cs.Models.DAOs;

namespace Domaci.cs.Controller
{
    public class StudentController
    {
        private readonly StudentDAO _students;
        public StudentController()
        {
            _students = new StudentDAO();
        }

        public void Create(string Prezime, string Ime, string datumRodjenja, string adresaStanovanja, string kontaktTelefon, string email, string brojIndeksa, string godinaUpisa, string trenutnaGodina, string status)
        {
            _students.Add(Prezime, Ime, datumRodjenja, adresaStanovanja, kontaktTelefon, email, brojIndeksa, godinaUpisa, trenutnaGodina, status);
        }

        public void Update(string Prezime, string Ime, string datumRodjenja, string adresaStanovanja, string kontaktTelefon, string email, string brojIndeksa, string godinaUpisa, string trenutnaGodina, string status, Student student)
        {
            _students.Update(Prezime, Ime, datumRodjenja, adresaStanovanja, kontaktTelefon, email, brojIndeksa, godinaUpisa, trenutnaGodina, status, student);
        }

        public string returnAdress(Student student)
        {
            return _students.returnAdress(student);
        }


        public string returnStatus(Student student)
        {
            return _students.returnStatus(student);
        }

        public bool checkEmail(string Email)
        {
            return _students.unusedEmail(Email);
        }
        public List<Student> GetAllStudents()
        {
            return _students.GetAll();
        }

        public void Delete(Student student)
        {
            _students.Remove(student);

        }

        public void Subscribe(IObserver observer)
        {
            _students.Subscribe(observer);
        }


        public int returnStudentId(Student student)
        {
            return _students.returnId(student);
        }

        public List<Predmet> availablePredmeti(Student student)
        {
            return _students.availablePredmeti(student);
        }

        public List<Predmet> polozeniPredemti(Student student)
        {
            return _students.polozeniPredmeti(student);
        }


        public List<Predmet> nepolozeniPredemti(Student student)
        {
            return _students.nepolozeniPredmeti(student);
        }

        public void addNPPredmet(Student student, Predmet predmet)
        {
            _students.addNPPredmet(student, predmet);
        }

        public void upisiOcenu(Student student, Predmet predmet, string ocena, string datum)
        {
            _students.upisiOcenu(student, predmet, ocena, datum);
        }

        public List<PolozeniDTO> getAllPolozeni(Student student)
        {
            return _students.getAllPolozeni(student);
        }

        public void removeOcena(Student student, PolozeniDTO polozeni)
        {
            _students.removeOcena(student, polozeni);
        }


        public void removeNPPredmet(Student student, Predmet predmet)
        {
            _students.removeNPPredmet(student, predmet);
        }

        public double? findProsecna(Student student)
        {
            return _students.findProsecna(student);
        }

        public int? findESPB(Student student)
        {
            return _students.findESPB(student);
        }

        public Student findStudentByEmail(string email)
        {
            return _students.FindStudentByEmail(email);
        }




    }
}
