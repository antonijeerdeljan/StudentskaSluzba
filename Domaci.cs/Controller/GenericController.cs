using Domaci.cs.Models.DAOs;
using Domaci.cs.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Controller
{
    public class GenericController
    {
    }
}

    /*public class StudentController
    {
        private readonly StudentDAO _students;
        public StudentController()
        {
            _students = new StudentDAO();
        }

        public void Create(string Prezime, string Ime, DateTime datumRodjenja, string adresaStanovanja, string kontaktTelefon, string email, string brojIndeksa, int godinaUpisa, int trenutnaGodina, int status)
        {
            _students.Add(Prezime, Ime, datumRodjenja, adresaStanovanja, kontaktTelefon, email, brojIndeksa, godinaUpisa, trenutnaGodina, status);
        }

        public void Update(string Prezime, string Ime, DateTime datumRodjenja, string adresaStanovanja, string kontaktTelefon, string email, string brojIndeksa, int godinaUpisa, int trenutnaGodina, int status, Student student)
        {
            _students.Update(Prezime, Ime, datumRodjenja, adresaStanovanja, kontaktTelefon, email, brojIndeksa, godinaUpisa, trenutnaGodina, status, student);
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
    }
}
    */