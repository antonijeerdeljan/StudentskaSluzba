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
    /// Interaction logic for IzlistajSveProfesore.xaml
    /// </summary>
    public partial class IzlistajSveProfesore : Window
    {
        private readonly ProfesorController _prfController;
        public ObservableCollection<Profesor> Profesors { get; set; }
        public Profesor SelectedProfesors { get; set; }

        public IzlistajSveProfesore()
        {
            InitializeComponent();
            DataContext = this;
            _prfController = new ProfesorController();
            Profesors = new ObservableCollection<Profesor>(_prfController.GetAllProfesors());

        }


        public Profesor selectedProfesors()
        {
            return SelectedProfesors;
        }
        private void dodajPredmet_Button_Click(object sender, RoutedEventArgs e)
        {
            selectedProfesors();
            Close();
        }

        private void Odustani_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }




    }
}
