using Domaci.cs.Controller;
using System;
using System.Collections.Generic;
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
using Domaci.cs.Observers;
using System.Collections.ObjectModel;
using Domaci.cs.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Front
{
    /// <summary>
    /// Interaction logic for Dodaj_predmet_profesoru.xaml
    /// </summary>
    public partial class Dodaj_predmet_profesoru : Window
    {
        private readonly PredmetController _predmetController;
        private readonly Profesor _selectedProfesor;

        public Predmet SelectedPredmet { get; set; }

        public ObservableCollection<Predmet> MoguciPredmeti { get; set; }

        public Dodaj_predmet_profesoru(Profesor selektovanProfesor)
        {
            InitializeComponent();
            _selectedProfesor = selektovanProfesor;
            DataContext = this;
            _predmetController = new PredmetController();

            MoguciPredmeti = new ObservableCollection<Predmet>(_predmetController.GetAllProfesorOpcijePredmeti(selektovanProfesor.ProfesorId));
            this.StudentData.ItemsSource = MoguciPredmeti;
        }

        private void Potvrda_button_click(object sender, RoutedEventArgs e)
        {
            if(SelectedPredmet != null)
            {
                _predmetController.AddPredmetToProfesor(_selectedProfesor.ProfesorId, SelectedPredmet);
                Close();
            }
        }

        private void Odustani_button_click(object sender, RoutedEventArgs e)
        {
                Close();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
