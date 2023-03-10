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
    /// Interaction logic for SluzbaWindow.xaml
    /// </summary>
    public partial class SluzbaWindow : Window
    {
        public SluzbaWindow()
        {
            InitializeComponent();
        }

        private void Referent_Button_Login(object sender, RoutedEventArgs e)
        {
            ReferentLogin rf = new ReferentLogin();
            rf.Show();
            Close();
        }

        private void Student_Button_Login(object sender, RoutedEventArgs e)
        {
            StudentLogin studentlogin = new StudentLogin();
            studentlogin.Show();
            Close();

        }
    }
}
