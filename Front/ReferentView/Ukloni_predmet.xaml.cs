using Domaci.cs.Controller;
using Domaci.cs.Models;
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
    /// Interaction logic for Ukloni_predmet.xaml
    /// </summary>
    public partial class Ukloni_predmet : Window
    {
        private readonly PredmetController _predmetController;

        private readonly Predmet selektovanPredmet;

        public Ukloni_predmet(Predmet selectedPredmet, PredmetController prdCont)
        {
            InitializeComponent();
            selektovanPredmet = selectedPredmet;
            DataContext = this;
            _predmetController = prdCont;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _predmetController.DeleteProfesorFromPredmet(selektovanPredmet.PredmetId);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
