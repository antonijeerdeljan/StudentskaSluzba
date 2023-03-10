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
    /// Interaction logic for StudentPasswordRecoveryConfirmation.xaml
    /// </summary>
    public partial class StudentPasswordRecoveryConfirmation : Window
    {
        public StudentPasswordRecoveryConfirmation()
        {
            InitializeComponent();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            StudentLogin reg = new StudentLogin();
            reg.Show();
            Close();
        }
    }
}
