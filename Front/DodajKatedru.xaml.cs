using Domaci.cs.Controller;
using Domaci.cs.Models;
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
    /// Interaction logic for DodajKatedru.xaml
    /// </summary>
    public partial class DodajKatedru : Window, INotifyPropertyChanged
    {
        public ObservableCollection<ComboBoxItem> cbItems { get; set; }
        public ComboBoxItem SelectedcbItem { get; set; }

        private readonly ProfesorController profesorController;
        private readonly KatedraController ktdCont;
        public DodajKatedru()
        {
            ktdCont = new KatedraController();
            profesorController = new ProfesorController();
            InitializeComponent();
            DataContext = this;


            List<Profesor> profe = new List<Profesor>();
            profe = profesorController.GetAllProfesors();
            List<String> imena = new List<String>();
            foreach (Profesor profesor in profe)
            {
                imena.Add(profesor.Broj_Licne + " " + profesor.Ime +" "+ profesor.Prezime);
            }
            Combobox.ItemsSource = imena;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ktdCont.createKatedra(Sifra_Katedre, Naziv_Katedre, sefKatedreId);
            Close();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
