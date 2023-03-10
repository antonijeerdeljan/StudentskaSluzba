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
    /// Interaction logic for Brisanje_ocene.xaml
    /// </summary>
    public partial class Brisanje_ocene : Window
    {
        private readonly StudentController studentController;
        private readonly Student student;
        private readonly PolozeniDTO polozenidto;
        public Brisanje_ocene(Student studentret, PolozeniDTO polozeni, StudentController stdController)
        {
            student = studentret;
            studentController = stdController;
            polozenidto = polozeni;
            InitializeComponent();
        }


        private void deleteOcena_Button_Click(object sender, RoutedEventArgs e)
        {
            studentController.removeOcena(student, polozenidto);
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            studentController.removeOcena(student, polozenidto);

        }
    }
}
