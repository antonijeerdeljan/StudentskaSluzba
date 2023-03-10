using Domaci.cs.Controller;
using Domaci.cs.Models;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Brisanje_studenta.xaml
    /// </summary>
    public partial class Brisanje_studenta : Window
    {
        private readonly StudentController _studentController;
        private readonly Student selectedstd;

        Student SelectedStudent { get; set; }
        public Brisanje_studenta(StudentController studentController,Student student)
        {
            InitializeComponent();
            DataContext = this;
            _studentController = studentController;
            selectedstd = student;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _studentController.Delete(selectedstd);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
