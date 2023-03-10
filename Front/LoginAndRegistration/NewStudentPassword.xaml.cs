using Domaci.cs.Controller;
using Domaci.cs.PasswordHashing;
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
    /// Interaction logic for NewStudentPassword.xaml
    /// </summary>
    public partial class NewStudentPassword : Window, INotifyPropertyChanged
    {
        private readonly string _Email;
        private readonly PasswordHashing _passHash;
        private readonly LoginRegisterController _logregController;
        public NewStudentPassword(string Email, PasswordHashing passwordHashing, LoginRegisterController loginRegister)
        {
            InitializeComponent();
            _logregController = loginRegister;
            _passHash= passwordHashing;
            DataContext= this;
            _Email = Email;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _confirmPassword;
        public string confirmPassword
        {
            get => _confirmPassword;
            set
            {
                if (value != _confirmPassword)
                {
                    _confirmPassword = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _newPassword;
        public string newPassword
        {
            get => _newPassword;
            set
            {
                if (value != _newPassword)
                {
                    _newPassword = value;
                    OnPropertyChanged();
                }
            }
        }

        private void ChangePassword_Button_Click(object sender, RoutedEventArgs e)
        {
            if (newPassword != confirmPassword || newPassword == null || confirmPassword == null)
            {
                //sifre se ne poklapaju
            }
            else
            {
                string HashedPassword = _passHash.HashPassword(newPassword);
                _logregController.changeStudentPassword(_Email, HashedPassword);

            }
            StudentLogin studlog = new StudentLogin();
            studlog.Show();
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
