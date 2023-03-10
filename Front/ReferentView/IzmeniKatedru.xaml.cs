using Domaci.cs.Controller;
using Domaci.cs.Models;
using Front;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for IzmeniKatedru.xaml
    /// </summary>
    public partial class IzmeniKatedru : Window
    {
        private readonly KatedraController ktdCont;
        private readonly ProfesorController profesorController;
        private readonly Katedra ktd;


        public IzmeniKatedru(Katedra SelectedKatedra)
        {
            ktd = SelectedKatedra;
            ktdCont = new KatedraController();
            profesorController = new ProfesorController();

            InitializeComponent();
            DataContext = this;
            Sifra_Katedre = SelectedKatedra.Sifra_Katedre;
            Naziv_Katedre = SelectedKatedra.Naziv_Katedre;

            List<Profesor> profe = new List<Profesor>();
            profe = profesorController.GetAllProfesors();
            List<String> imena = new List<String>();
            foreach (Profesor profesor in profe)
            {
                imena.Add(profesor.Broj_Licne + " " + profesor.Ime + " " + profesor.Prezime);
            }
            Combobox.ItemsSource = imena;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ktdCont.setSefKatedre(ktd, sefKatedreId);
            Close();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private int _Sifra_Katedre;
        public int Sifra_Katedre
        {
            get => _Sifra_Katedre;
            set
            {
                if (value != _Sifra_Katedre)
                {
                    _Sifra_Katedre = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Naziv_Katedre;
        public string Naziv_Katedre
        {
            get => _Naziv_Katedre;
            set
            {
                if (value != _Naziv_Katedre)
                {
                    _Naziv_Katedre = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _sefKatedreId;
        public string sefKatedreId
        {
            get => _sefKatedreId;
            set
            {
                if (value != _sefKatedreId)
                {
                    _sefKatedreId = value;
                    OnPropertyChanged();
                }
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}




