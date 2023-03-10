using Domaci.cs.Controller;
using Domaci.cs.Models;
using Domaci.cs.Models.DAOs;
using Domaci.cs.Observers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Front
{
    /// <summary>
    /// Interaction logic for Izmena_studenta.xaml
    /// </summary>
    public partial class Izmena_studenta : Window, INotifyPropertyChanged, IObserver
    {
        private readonly StudentController studentController;
        private readonly PredmetController predmetController;
        private readonly Student student;
        private readonly StudentDTO studentdto = new StudentDTO();

        public ObservableCollection<Predmet> Nepolozeni { get; set; }
        public Predmet SelectedNeplozeni { set; get; }
        public ObservableCollection<PolozeniDTO> Polozeni { get; set; }
        public PolozeniDTO SelectedPolozeni { set; get; }


        public Izmena_studenta(StudentController stdControler, Student selektovan, PredmetController prfControler)
        {


            predmetController = prfControler;
            studentController = stdControler;
            student = selektovan;
            stdControler.Subscribe(this);

            List<Predmet> pred = new List<Predmet>();

            pred = studentController.nepolozeniPredemti(student);

            Nepolozeni = new ObservableCollection<Predmet>(studentController.nepolozeniPredemti(student));
            Polozeni = new ObservableCollection<PolozeniDTO>(studentController.getAllPolozeni(student));


            studentdto.FirstName = selektovan.Ime;
            studentdto.LastName = selektovan.Prezime;
            studentdto.DatumRodj = selektovan.Datum_Rodjenja.ToString();
            studentdto.AdresaStan = stdControler.returnAdress(selektovan);
            studentdto.BrojTel = selektovan.Kontakt_Telefon;
            studentdto.Email = selektovan.E_Mail;
            studentdto.BrojIndeksa = selektovan.Broj_Indeksa;
            studentdto.GodinaUpisa = selektovan.Godina_Upisa.ToString();
            studentdto.TrenuntaGodina = selektovan.Trenunta_Godina.ToString();
            studentdto.Status = stdControler.returnStatus(selektovan);

            InitializeComponent();

            DataContext = this;



            FirstName = studentdto.FirstName;
            LastName = studentdto.LastName;
            DatumRodj = studentdto.DatumRodj.ToString();
            AdresaStan = studentdto.AdresaStan;
            BrojTel = studentdto.BrojTel.ToString();
            Email = studentdto.Email.ToString();
            BrojIndeksa = studentdto.BrojIndeksa;
            GodinaUpisa = studentdto.GodinaUpisa;
            TrenutnaGodina = studentdto.TrenuntaGodina;
            Status = studentdto.Status;



            //Label1.Content = "Prosecna ocena:" + " " + Math.Round((decimal)studentController.findProsecna(student), 2);
            //Label2.Content = "Ukupno ESPB:" + " " + studentController.findESPB(student);

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }




        private string _index;
        public string Index
        {
            get => _index;
            set
            {
                if (value != _index)
                {
                    _index = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _FirstName;
        public string FirstName
        {
            get => _FirstName;
            set
            {
                if (value != _FirstName)
                {
                    _FirstName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _LastName;
        public string LastName
        {
            get => _LastName;
            set
            {
                if (value != _LastName)
                {
                    _LastName = value;
                    OnPropertyChanged();
                }
            }
        }




        private string _DatumRodj;
        public string DatumRodj
        {
            get => _DatumRodj;
            set
            {
                if (value != _DatumRodj)
                {
                    _DatumRodj = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _AdresaStan;
        public string AdresaStan
        {
            get => _AdresaStan;
            set
            {
                if (value != _AdresaStan)
                {
                    _AdresaStan = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _BrojTel;
        public string BrojTel
        {
            get => _BrojTel;
            set
            {
                if (value != _BrojTel)
                {
                    _BrojTel = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Email;
        public string Email
        {
            get => _Email;
            set
            {
                if (value != _Email)
                {
                    _Email = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _BrojIndeksa;
        public string BrojIndeksa
        {
            get => _BrojIndeksa;
            set
            {
                if (value != _BrojIndeksa)
                {
                    _BrojIndeksa = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _GodinaUpisa;
        public string GodinaUpisa
        {
            get => _GodinaUpisa;
            set
            {
                if (value != _GodinaUpisa)
                {
                    _GodinaUpisa = value;
                    OnPropertyChanged();
                }
            }
        }



        private string _TrenutnaGodina;
        public string TrenutnaGodina
        {
            get => _TrenutnaGodina;
            set
            {
                if (value != _TrenutnaGodina)
                {
                    _TrenutnaGodina = value;
                    OnPropertyChanged();
                }
            }
        }



        private string _Status;

        public string Status
        {
            get => _Status;
            set
            {
                if (value != _Status)
                {
                    _Status = value;
                    OnPropertyChanged();
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            studentController.Update(LastName, FirstName, DatumRodj, AdresaStan, BrojTel, Email, BrojIndeksa, GodinaUpisa, TrenutnaGodina, Status, student);
            Close();
        }

        private void dodajStunNaPred_Button_Click(object sender, RoutedEventArgs e)
        {
            Dodavanje_predmeta dodavanjeStudNaPred = new Dodavanje_predmeta(student, studentController);
            dodavanjeStudNaPred.Show();
        }

        private void ukloniStudSaPred_Button_Click(object sender, RoutedEventArgs e)
        {
            Uklanjanje_predmeta uklanjanje_Predmeta = new Uklanjanje_predmeta(SelectedNeplozeni, studentController, student);
            uklanjanje_Predmeta.Show();


        }

        private void Polaganje_Button_Click(object sender, RoutedEventArgs e)
        {
            Unos_ocene unosoc = new Unos_ocene(SelectedNeplozeni, studentController, student);
            unosoc.Show();
            Close();
        }

        private void PonistiOcenuButton_Click(object sender, RoutedEventArgs e)
        {
            Brisanje_ocene brisanjeOcene = new Brisanje_ocene(student, SelectedPolozeni, studentController);
            brisanjeOcene.Show();

        }

        private void UpdateNepolozeniList()
        {
            Nepolozeni.Clear();
            foreach (var nepolozeni in studentController.nepolozeniPredemti(student))
            {
                Nepolozeni.Add(nepolozeni);
            }
        }

        private void UpdatePolozeniList()
        {
            Polozeni.Clear();
            foreach (var nepolozeni in studentController.getAllPolozeni(student))
            {
                Polozeni.Add(nepolozeni);
            }
        }

        public void Update()
        {
            UpdateNepolozeniList();
            UpdatePolozeniList();
        }
    }
}
