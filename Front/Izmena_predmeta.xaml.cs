using Domaci.cs.Controller;
using Domaci.cs.Models;
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

namespace Front
{
    /// <summary>
    /// Interaction logic for Izmena_predmeta.xaml
    /// </summary>
    public partial class Izmena_predmeta : Window, INotifyPropertyChanged
    {

        private readonly PredmetController predmetController;
        private readonly ProfesorController profesorController;
        private readonly Predmet predmet;


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private int _sifra;

        public int Sifra
        {
            get => _sifra;
            set
            {
                if (value != _sifra)
                {
                    _sifra = value;
                    OnPropertyChanged();
                }
            }

        }

        private string _nazivPredmeta;

        public string NazivPredmeta
        {
            get => _nazivPredmeta;
            set
            {
                if (value != _nazivPredmeta)
                {
                    _nazivPredmeta = value;
                    OnPropertyChanged();
                }
            }

        }

        private int _espBodovi;

        public int EspBodovi
        {
            get => _espBodovi;
            set
            {
                if (value != _espBodovi)
                {
                    _espBodovi = value;
                    OnPropertyChanged();
                }
            }

        }

        private int _godinaIzvodjenja;
        public int GodinaIzvodjenja
        {
            get => _godinaIzvodjenja;
            set
            {
                if (value != _godinaIzvodjenja)
                {
                    _godinaIzvodjenja = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _semestarIzvodjenja;
        public int SemestarIzvodjenja
        {
            get => _semestarIzvodjenja;
            set
            {
                if (value != _semestarIzvodjenja)
                {
                    _semestarIzvodjenja = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _profesorPredaje;

        public string ProfesorPredaje
        {
            get => _profesorPredaje;
            set
            {
                if (value != _profesorPredaje)
                {
                    _profesorPredaje = value;
                    OnPropertyChanged("ProfesorPredaje");
                }
            }
        }
        public Izmena_predmeta(PredmetController prdControler , ProfesorController prfControler,  Predmet izabran )
        {
            InitializeComponent();
            DataContext = this;
            predmetController = prdControler;
            profesorController = prfControler;
            predmet = izabran;

            NazivPredmeta = izabran.Naziv_predmeta;
            Sifra = izabran.Sifra_predmeta;
            EspBodovi = izabran.ESPB_Bodovi;
            GodinaIzvodjenja = izabran.Godina_izvodjenja_predmeta;
            SemestarIzvodjenja = (int) izabran.Semestar;

            if (izabran.ProfesorId != null)
            {
                Profesor currentProfesor = prfControler.GetProfesorById(izabran.ProfesorId);
                ProfesorPredaje = currentProfesor.Ime + ' '  + currentProfesor.Prezime;

                Dodaj.IsEnabled = false;
                Ukloni.IsEnabled = true;
            }else
            {
                Dodaj.IsEnabled = true;
                Ukloni.IsEnabled = false;
            }
        }

        private void AddProfessor_Click(object sender, RoutedEventArgs e)
        {
            Odaberi_profesora window = new Odaberi_profesora(profesorController, predmet);
            window.Show();
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            predmetController.Update(Sifra, NazivPredmeta, EspBodovi, GodinaIzvodjenja, SemestarIzvodjenja,predmet);
            Close();
            
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DeleteProfessorFromPredmet_Click(object sender, RoutedEventArgs e)
        {
            Ukloni_predmet window = new Ukloni_predmet(predmet, predmetController);
            window.Show();
        
        }
       
    }
}
