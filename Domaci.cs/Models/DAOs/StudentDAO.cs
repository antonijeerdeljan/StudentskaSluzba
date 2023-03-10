using Domaci.cs.Controller;
using Domaci.cs.Data;
using Domaci.cs.Observers;
using Microsoft.EntityFrameworkCore;
using Domaci.cs.PasswordHashing;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Models.DAOs
{

    public class StudentDAO : ISubject
    {
        private readonly List<IObserver> _observers;
        private readonly List<Student> _students;
        private readonly DataDbContext db;



        public StudentDAO()
        {
            db = new DataDbContext();
            _students = new List<Student>();
            _students = db.Students.ToList();
            _observers = new List<IObserver>();
        }



        public Student createStud(string Prezime, string Ime, string datumRodjenja, string adresaStanovanja, string kontaktTelefon, string email, string brojIndeksa, string godinaUpisa, string trenutnaGodina, string status)
        {
            int godup = Int16.Parse(godinaUpisa);
            DateTime dateRodj = DateTime.Parse(datumRodjenja);

            int stringToIntStatus(string trenutnaGodina)
            {
                switch (trenutnaGodina)
                {
                    case "Budzet":
                        return 0;
                    case "Samofinansiranje":
                        return 1;
                    default: return -1;
                }

            }
            int st = stringToIntStatus(status);

            int stringToIntGodinaStud(string trenutnaGodina)
            {
                switch (trenutnaGodina)
                {
                    case "I (prva)":
                        return 1;
                    case "II (druga)":
                        return 2;
                    case "III (treca)":
                        return 3;
                    case "IV (cetvrta)":
                        return 4;
                    default: return 0;
                }

            }
            int trenutnaGod = stringToIntGodinaStud(trenutnaGodina);

            List<string> adresaTemp = adresaStanovanja.Split(',').ToList<string>();
            Adresa adresa = new Adresa();
            adresa.Broj = adresaTemp[0];
            adresa.Grad = adresaTemp[1];
            adresa.Drzava = adresaTemp[2];
            adresa.Ulica = adresaTemp[3];
            Status statustemp = (Status)st;

            Student student = new Student();
            student.Prezime = Prezime;
            student.Ime = Ime;
            student.Datum_Rodjenja = dateRodj;
            student.Adresa = adresa;
            student.Kontakt_Telefon = kontaktTelefon;
            student.E_Mail = email;
            student.Broj_Indeksa = brojIndeksa;
            student.Godina_Upisa = godup;
            student.Trenunta_Godina = trenutnaGod;
            student.Status = statustemp;
            student.Sifra = HashPassword(brojIndeksa);
            return student;
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public Student FindStudentByEmail(string email)
        {
            Student student = db.Students.Where(c => c.E_Mail.Contains(email))
                                         .FirstOrDefault();
            return student;
        }

        public bool unusedEmail(string Email)
        {
            if (db.Students.Where(s => s.E_Mail.Contains(Email)).FirstOrDefault() != null || db.Referents.Where(r => r.Email.Contains(Email)).FirstOrDefault() != null)
                return true;
            else
                return false;

        }

        public void Add(string Prezime, string Ime, string datumRodjenja, string adresaStanovanja, string kontaktTelefon, string email, string brojIndeksa, string godinaUpisa, string trenutnaGodina, string status)
        {

            Student student = new Student();
            student = createStud(Prezime, Ime, datumRodjenja, adresaStanovanja, kontaktTelefon, email, brojIndeksa, godinaUpisa, trenutnaGodina, status);
            db.Students.Add(student);
            db.SaveChanges();
            NotifyObservers();
        }

        public void Remove(Student student)
        {
            db.Students.Remove(student);
            db.SaveChanges();
            NotifyObservers();
        }


        public string returnStatus(Student student)
        {
            if (student.Status == 0)
            {
                return ("Budzet");
            }
            else
            {
                return ("Samofinansiranje");
            }
        }

        public string returnAdress(Student student)
        {
            int addrid = student.IDAdresa;
            Adresa addr = db.Adresas.FirstOrDefault(c => c.AdresaId == addrid);
            string retaddr = addr.Grad + "," + addr.Drzava + "," + addr.Ulica + "," + addr.Broj;
            return retaddr;
        }
        public void Update(string Prezime, string Ime, string datumRodjenja, string adresaStanovanja, string kontaktTelefon, string email, string brojIndeksa, string godinaUpisa, string trenutnaGodina, string status, Student student)
        {
            int Id = 0;
            Student tempStud = new Student();
            tempStud = db.Students.FirstOrDefault(c => c.Broj_Indeksa == student.Broj_Indeksa);
            Id = tempStud.StudentId;
            db.Students.Remove(tempStud);
            Student tempStud2 = new Student();
            tempStud2 = createStud(Prezime, Ime, datumRodjenja, adresaStanovanja, kontaktTelefon, email, brojIndeksa, godinaUpisa, trenutnaGodina, status);
            tempStud2.StudentId = Id;
            db.Students.Add(tempStud2);
            db.SaveChanges();
            NotifyObservers();
        }

        public List<Student> GetAll()
        {

            List<Student> std = db.Students.Include(x => x.Ocene).ToList();
            List<Student> ret = new List<Student>();
            foreach (Student st in std)
            {
                double prosek = 0;
                foreach (Ocena ocena in st.Ocene)
                {
                    prosek += ocena.Upisana_Ocena;
                }

                if (st.Ocene.Count != 0) prosek /= st.Ocene.Count;
                st.Prosecna_Ocena = (double?)Math.Round(prosek, 2);
                //st.Prosecna_Ocena = findProsecna(st);
            }
            return std;

        }

        public double? findProsecna(Student student)
        {
            List<Ocena> ocene = new List<Ocena>();
            ocene = gettAllOcene(student);
            double suma = 0;
            int i = ocene.Count();
            double prosecna = 0;
            foreach (var o in ocene)
            {
                suma = suma + o.Upisana_Ocena;
            }
            prosecna = suma / i;
            return prosecna;
        }

        public int? findESPB(Student student)
        {
            List<Ocena> ocene = new List<Ocena>();
            ocene = gettAllOcene(student);
            int suma = 0;
            foreach (var o in ocene)
            {
                suma = suma + o.Predmet.ESPB_Bodovi;
            }
            return suma;

        }


        public int returnId(Student student)
        {
            int id = student.StudentId;
            return id;
        }

        public List<Predmet> polozeniPredmeti(Student student)
        {
            int studentId = returnId(student);

            List<StudentPPredmet> polozeniPredmetiSvi = new List<StudentPPredmet>();
            polozeniPredmetiSvi = db.StudentPPredmet.ToList();
            List<Predmet> samoPredmeti = new List<Predmet>();

            foreach (var studentPPredmet in polozeniPredmetiSvi)
            {
                if (studentPPredmet.StudentId == studentId)
                {
                    samoPredmeti.Add(studentPPredmet.Predmet);
                }
            }

            return samoPredmeti;

        }

        public void addNPPredmet(Student student, Predmet predmet)
        {
            int studid = student.StudentId;
            int predid = predmet.PredmetId;
            StudentNPPredmet studentnppredmet = new StudentNPPredmet();
            studentnppredmet.predmet = predmet;
            studentnppredmet.student = student;

            studentnppredmet.StudentId = studid;
            studentnppredmet.PredmetId = predid;
            db.StudentNPPredmet.Add(studentnppredmet);
            db.SaveChanges();
            NotifyObservers();


        }


        public List<Predmet> findPredmetsById(List<int> listID)
        {
            List<Predmet> prdOut = new List<Predmet>();
            List<Predmet> predmets = new List<Predmet>();
            predmets = db.Predmets.ToList();

            foreach (var predmet in predmets)
            {
                foreach (int id in listID)
                {
                    if (predmet.PredmetId == id)
                    {
                        prdOut.Add(predmet);
                    }
                }
            }
            return prdOut;
        }




        public List<Predmet> nepolozeniPredmeti(Student student)
        {
            int studentId = returnId(student);

            List<StudentNPPredmet> nepolozeniPredmetiSvi = new List<StudentNPPredmet>();
            List<int> predid = new List<int>();

            nepolozeniPredmetiSvi = db.StudentNPPredmet.ToList();
            List<Predmet> samoPredmeti = new List<Predmet>();

            foreach (var studentNPPredmet in nepolozeniPredmetiSvi)
            {
                if (studentNPPredmet.StudentId == studentId)
                {
                    predid.Add(studentNPPredmet.PredmetId);
                }
            }

            samoPredmeti = findPredmetsById(predid);

            return samoPredmeti;

        }


        public List<Predmet> availablePredmeti(Student student)
        {
            List<Predmet> sviPredmeti = new List<Predmet>();
            sviPredmeti = db.Predmets.ToList();
            List<Predmet> polozeniPredmetiList = polozeniPredmeti(student);
            List<Predmet> neplozeniPredmetiList = nepolozeniPredmeti(student);


            //od glave liste svi predmeti, oduzete su liste polozenih i nepolozenih predmeta
            IEnumerable<Predmet> predmetiList1 = sviPredmeti.Except(polozeniPredmetiList);
            IEnumerable<Predmet> predmetiList2 = predmetiList1.Except(neplozeniPredmetiList);

            int godinaStudija = student.Trenunta_Godina;

            List<Predmet> finalPredmet = new List<Predmet>();

            foreach (var pred in predmetiList2)
            {
                if (pred.Godina_izvodjenja_predmeta <= godinaStudija)
                {
                    finalPredmet.Add(pred);
                }
            }

            return finalPredmet;
        }


        public void removeNPPredmet(Student student, Predmet predmet)
        {
            StudentNPPredmet studentnpp = new StudentNPPredmet();
            studentnpp = db.StudentNPPredmet.FirstOrDefault(c => c.student == student && c.predmet == predmet);
            db.StudentNPPredmet.Remove(studentnpp);
            db.SaveChanges();
            NotifyObservers();
        }





        public void upisiOcenu(Student student, Predmet predmet, string Ocena, string datum)
        {
            removeNPPredmet(student, predmet);
            Ocena ocena = new Ocena();
            StudentPPredmet studentPPredmet = new StudentPPredmet();
            ocena.Student = student;
            ocena.Predmet = predmet;
            ocena.Upisana_Ocena = Int16.Parse(Ocena);
            ocena.Datum_Polaganja = DateTime.Parse(datum);

            studentPPredmet.Student = student;
            studentPPredmet.Predmet = predmet;
            studentPPredmet.PredmetId = predmet.PredmetId;
            studentPPredmet.StudentId = student.StudentId;

            db.Ocenas.Add(ocena);
            db.StudentPPredmet.Add(studentPPredmet);
            db.SaveChanges();
            NotifyObservers();
        }
        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public List<PolozeniDTO> getAllPolozeni(Student student)
        {
            List<PolozeniDTO> list = new List<PolozeniDTO>();
            //PolozeniDTO list1 = new PolozeniDTO();
            List<Ocena> studocene = gettAllOcene(student);
            foreach (Ocena ocena in studocene)
            {
                PolozeniDTO list1 = new PolozeniDTO();
                list1.Upisana_Ocena = ocena.Upisana_Ocena;
                list1.Sifra_predmeta = ocena.Predmet.Sifra_predmeta.ToString();
                list1.ESPB_Bodovi = ocena.Predmet.ESPB_Bodovi;
                list1.Naziv_predmeta = ocena.Predmet.Naziv_predmeta;
                list1.Datum_Polaganja = ocena.Datum_Polaganja;
                list.Add(list1);
            }
            return list;
        }


        public void removeOcena(Student student, PolozeniDTO polozeni)
        {
            Ocena ocena = new Ocena();
            Predmet predmet = new Predmet();

            predmet = db.Predmets.FirstOrDefault(c => c.Sifra_predmeta == Int32.Parse(polozeni.Sifra_predmeta));

            ocena = findOcena(student, predmet.PredmetId);

            db.Ocenas.Remove(ocena);



            //obirisati iz polozenih

            StudentPPredmet studentpp = new StudentPPredmet();
            studentpp = db.StudentPPredmet.FirstOrDefault(c => c.StudentId == student.StudentId && c.PredmetId == predmet.PredmetId);
            db.StudentPPredmet.Remove(studentpp);

            //dodati u nepolozene
            StudentNPPredmet studentnpp = new StudentNPPredmet();
            studentnpp.predmet = predmet;
            studentnpp.student = student;
            studentnpp.StudentId = student.StudentId;
            studentnpp.PredmetId = predmet.PredmetId;

            db.StudentNPPredmet.Add(studentnpp);

            db.SaveChanges();

            NotifyObservers();


        }

        public Ocena findOcena(Student student, int predmetid)
        {
            List<Ocena> ocene = gettAllOcene(student);
            Ocena ocena = new Ocena();
            ocena = ocene.Find(c => c.Predmet.PredmetId == predmetid);
            return ocena;
        }




        public List<Ocena> gettAllOcene(Student student)
        {
            List<Ocena> ocene = new List<Ocena>();
            List<Ocena> studocene = new List<Ocena>();
            ocene = db.Ocenas.ToList();
            foreach (Ocena ocena in ocene)
            {
                if (ocena.Student.Broj_Indeksa == student.Broj_Indeksa)
                {
                    studocene.Add(ocena);
                }
            }
            return studocene;

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
