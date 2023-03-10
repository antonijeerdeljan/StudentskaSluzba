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
using static System.Net.Mime.MediaTypeNames;

namespace Front
{
    /// <summary>
    /// Interaction logic for Dodaj_predmet.xaml
    /// </summary>
    public partial class Dodaj_predmet : Window, INotifyPropertyChanged
    {
        private readonly PredmetController _predmetController;

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

        public Dodaj_predmet(PredmetController predmetController)
        {
            InitializeComponent();
            DataContext = this;
            _predmetController = predmetController;

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {   
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _predmetController.Create(Sifra,NazivPredmeta,EspBodovi,GodinaIzvodjenja,SemestarIzvodjenja);
        }

    }
}
