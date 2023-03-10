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
    /// Interaction logic for Odaberi_profesora.xaml
    /// </summary>
    public partial class Odaberi_profesora : Window
    {
        public Profesor SelectedProfesor { get; set; }

        public ObservableCollection<Profesor> Profesori { get; set; }

        private  ProfesorController _profesorController;

        private PredmetController _predmetController;

        private Predmet _selectedPredmet { get; set; }
        
        public Odaberi_profesora(ProfesorController prfController, Predmet selektovanPredmet)
        {
            InitializeComponent();
            DataContext = this;
            _profesorController = prfController;
            Profesori = new ObservableCollection<Profesor>(_profesorController.GetAllProfesors());
            _selectedPredmet = selektovanPredmet;
            _predmetController = new PredmetController();
        }

        private void Potvrda_button_click(object sender, RoutedEventArgs e)
        {
            if (SelectedProfesor != null)
            {
                _predmetController.AddPredmetToProfesor(SelectedProfesor.ProfesorId, _selectedPredmet);
                Close();
            }
        }

        private void Odustani_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
