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
    /// Interaction logic for Brisanje_predmeta.xaml
    /// </summary>
    public partial class Brisanje_predmeta : Window
    {
        private readonly PredmetController _predmetController;
        private readonly Predmet selectedstd;

        Predmet SelectedPredmet { get; set; }
        public Brisanje_predmeta(PredmetController predmetController,Predmet predmet )
        {
            InitializeComponent();
            DataContext = this;
            _predmetController = predmetController;
            selectedstd = predmet;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _predmetController.Delete(selectedstd);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
