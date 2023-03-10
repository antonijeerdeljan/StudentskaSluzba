using Domaci.cs.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Domaci.cs.Models;
using System.Collections.ObjectModel;
using Domaci.cs.Observers;

namespace Front
{
    /// <summary>
    /// Interaction logic for IzmenaProfesora.xaml
    /// </summary>
    public partial class IzmenaProfesora : Window, INotifyPropertyChanged, IObserver
    {

        private readonly ProfesorController profController;
        private readonly PredmetController prdController;
        private readonly Profesor profesor;
        private readonly Predmet predmet;

        public Predmet SelectedPredmet { get; set; }

        public  ObservableCollection<Predmet> Predmeti { get; set; }

        public IzmenaProfesora(ProfesorController prfControler, PredmetController predmetController, Profesor selektovan)
        {
            InitializeComponent();
            DataContext = this;
            profController = prfControler;
            prdController = predmetController;
            prdController.Subscribe(this);
            prfControler.Subscribe(this);

            profesor = selektovan;

            Predmeti = new ObservableCollection<Predmet>(predmetController.GetAllProfesorPredmeti(selektovan.ProfesorId));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private string _Ime;
        public string Ime
        {
            get => _Ime;
            set
            {
                if (value != _Ime)
                {
                    _Ime = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Prezime;
        public string Prezime
        {
            get => _Prezime;
            set
            {
                if (value != _Prezime)
                {
                    _Prezime = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _adresaStanovanja;
        public string adresaStanovanja
        {
            get => _adresaStanovanja;
            set
            {
                if (value != _adresaStanovanja)
                {
                    _adresaStanovanja = value;
                    OnPropertyChanged();
                }
            }
        }



        private string _adresaKancelarije;
        public string adresaKancelarije
        {
            get => _adresaKancelarije;
            set
            {
                if (value != _adresaKancelarije)
                {
                    _adresaKancelarije = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _kontaktTelefon;
        public string kontaktTelefon
        {
            get => _kontaktTelefon;
            set
            {
                if (value != _kontaktTelefon)
                {
                    _kontaktTelefon = value;
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

        private string _Zvanje;
        public string Zvanje
        {
            get => _Zvanje;
            set
            {
                if (value != _Zvanje)
                {
                    _Zvanje = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _brojLicneKarte;
        public int brojLicneKarte
        {
            get => _brojLicneKarte;
            set
            {
                if (value != _brojLicneKarte)
                {
                    _brojLicneKarte = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _godineStaza;
        public int godineStaza
        {
            get => _godineStaza;
            set
            {
                if (value != _godineStaza)
                {
                    _godineStaza = value;
                    OnPropertyChanged();
                }
            }
        }

        


        private string _Katedra;
        public string Katedra
        {
            get => _Katedra;
            set
            {
                if (value != _Katedra)
                {
                    _Katedra = value;
                    OnPropertyChanged();
                }
            }
        }


        private DateTime _datumRodj;
        public DateTime datumRodj
        {
            get => _datumRodj;
            set
            {
                if (value != _datumRodj)
                {
                    _datumRodj = value;
                    OnPropertyChanged();
                }
            }
        }


        

        private void CancelButton_Click(object sender,RoutedEventArgs e)

        {
            Close();
        }

        private void IzmeniButton_Click(object sender, RoutedEventArgs e)
        {

                profController.Update(Ime, Prezime, datumRodj, adresaStanovanja, adresaKancelarije, kontaktTelefon, Email, brojLicneKarte, Zvanje, godineStaza, Katedra, profesor);
                Close();


        }

        private void Dodaj_predmet_click(object sender, RoutedEventArgs e)
        {
            Dodaj_predmet_profesoru window = new Dodaj_predmet_profesoru(profesor);
            window.Show();
            Update();

        }

        private void Ukloni_predmet_click(object sender, RoutedEventArgs e)
        {
            if (SelectedPredmet != null)
            {
                Ukloni_predmet window = new Ukloni_predmet(SelectedPredmet, prdController);
                window.Show();
            }
            Update();
        }



        public void UpdatePredmetList()
        {
            Predmeti.Clear();
            foreach (var nepolozeni in prdController.GetAllProfesorPredmeti(profesor.ProfesorId))
            {
                Predmeti.Add(nepolozeni);
            }


        }

        public void Update()
        {
            UpdatePredmetList();
        }
    }
}
