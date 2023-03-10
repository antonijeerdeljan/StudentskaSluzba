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
    /// Interaction logic for PasswordRecoveryConfirmation.xaml
    /// </summary>
    public partial class PasswordRecoveryConfirmation : Window
    {
        public PasswordRecoveryConfirmation()
        {
            InitializeComponent();
        }


        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            ReferentLogin reg = new ReferentLogin();
            reg.Show();
            Close();
        }
    }
}
