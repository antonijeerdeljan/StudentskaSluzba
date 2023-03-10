using Domaci.cs.Controller;
using Domaci.cs.Models;
using Domaci.cs.Observers;
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
    /// Interaction logic for Dodavanje_predmeta.xaml
    /// </summary>
    public partial class Dodavanje_predmeta : Window, IObserver
    {
        public Predmet SelectedPredmet { get; set; }
        public ObservableCollection<Predmet> Predmets { get; set; }



        private readonly Student student;
        private readonly StudentController stdController;
        List<Predmet> predmeti = new List<Predmet>();

        public Dodavanje_predmeta(Student studentSel,StudentController studentController)
        {

            InitializeComponent();
            DataContext = this;
            student = studentSel;
            stdController = studentController;
            stdController.Subscribe(this);
            Predmets = new ObservableCollection<Predmet>(stdController.availablePredmeti(student));
            this.dostupniGrid.ItemsSource = Predmets;//W
            int i = 0;
            


        }

        private void Odustani_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void dodajPredmet_Button_Click(object sender, RoutedEventArgs e)
        {
            stdController.addNPPredmet(student, SelectedPredmet);
            


        }

        void updateAvialableList()
        {
            Predmets.Clear();
            foreach (var prd in stdController.availablePredmeti(student))
            {
                Predmets.Add(prd);
            }

        }

        public void Update()
        {
            updateAvialableList();
        }
    }
}
