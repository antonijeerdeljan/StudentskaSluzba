using Domaci.cs.Controller;
using Domaci.cs.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    /// Interaction logic for Napravi_Katedru.xaml
    /// </summary>
    public partial class Napravi_Katedru : Window
    {
        public ObservableCollection<Katedra> Katedre { get; set; }
        private readonly KatedraController _ktdController;

        public Katedra SelectedKatedra { get; set; }

        public Napravi_Katedru()
        {
            InitializeComponent();
            DataContext = this;
            _ktdController = new KatedraController();
            Katedre = new ObservableCollection<Katedra>(_ktdController.GetAllKatedre());


        }

        private void Potvrda_button_click(object sender, RoutedEventArgs e)
        {
            DodajKatedru dk = new DodajKatedru();
            dk.Show();
            Close();
        }

        private void Odustani_button_click(object sender, RoutedEventArgs e)
        {

            Close();
        }


        private void Postavisefa_button_click(object sender, RoutedEventArgs e)
        {
            IzmeniKatedru izmeniktd = new IzmeniKatedru(SelectedKatedra);
            izmeniktd.Show();
            Close();
        }

    }
}
