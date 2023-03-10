using Domaci.cs.Controller;
using Domaci.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        private readonly LoginRegisterController _controller;
        private readonly string _Email;
        public Profile(string Email)
        {
            _Email = Email;
            InitializeComponent();
            _controller = new LoginRegisterController();
            DataContext= this;
            Referent printref = new Referent();
            printref = _controller.findReferentByEmail(Email);
            Label1.Content = printref.Name;
            Label2.Content = printref.Surname;
            Label3.Content = printref.Email;
        }

        private void PromeniSifru_Button_Click(object sender, RoutedEventArgs e)
        {
           ChangePassword changePassword = new ChangePassword(_Email);
           changePassword.Show();
        }

        private void LogOut_Button_Click(object sender, RoutedEventArgs e)
        { 

        }

    }
}
