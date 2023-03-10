using Domaci.cs.Controller;
using Domaci.cs.Models;
using Domaci.cs.Observers;
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

namespace Front
{
    /// <summary>
    /// Interaction logic for Uklanjanje_predmeta.xaml
    /// </summary>
    public partial class Uklanjanje_predmeta : Window
    {
        private readonly StudentController predmetController;
        private readonly Student student;
        private readonly Predmet predmet;
        public Uklanjanje_predmeta(Predmet predmetsel, StudentController prdController, Student selektovan)
        {
            student = selektovan;
            predmet = predmetsel;
            predmetController = prdController;
            InitializeComponent();
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Ukloni_Button_Click(object sender, RoutedEventArgs e)
        {
            predmetController.removeNPPredmet(student, predmet);
            Close();

        }



    }
}
