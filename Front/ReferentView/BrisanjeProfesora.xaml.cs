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
    /// Interaction logic for BrisanjeProfesora.xaml
    /// </summary>
    public partial class BrisanjeProfesora : Window
    {
        private readonly ProfesorController _profesorController;
        private readonly Profesor selectedprof;

        Profesor SelectProfesor { get; set; }

        public BrisanjeProfesora(ProfesorController profesorController, Profesor profesor)
        {
            InitializeComponent();
            DataContext = this;
            _profesorController = profesorController;
            selectedprof = profesor;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _profesorController.Delete(selectedprof);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
