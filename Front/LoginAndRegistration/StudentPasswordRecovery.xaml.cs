using Domaci.cs.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Front.LoginAndRegistration
{
    /// <summary>
    /// Interaction logic for StudentPasswordRecovery.xaml
    /// </summary>
    public partial class StudentPasswordRecovery : Window, INotifyPropertyChanged
    {
        private readonly LoginRegisterController _logreg;
        public StudentPasswordRecovery()
        {
            DataContext = this;
            _logreg = new LoginRegisterController();
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _Email;
        public string Email
        {
            get => _Email;
            set
            {
                if (value != _Email)
                {
                    _Email = value;
                    OnPropertyChanged();
                }
            }
        }


        private void PasswordReset_Button_Click(object sender, RoutedEventArgs e)
        {
            _logreg.forgotPasswordStudent(Email);
            StudentPasswordRecoveryConfirmation studentPasswordRecovery = new StudentPasswordRecoveryConfirmation();
            studentPasswordRecovery.Show();
            Close();
        }



        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            StudentLogin studlog = new StudentLogin();
            studlog.Show();
            Close();
        }
    }
}
