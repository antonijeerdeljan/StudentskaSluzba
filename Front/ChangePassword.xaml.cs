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

namespace Front
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window, INotifyPropertyChanged
    {
        private readonly string _Email;
        private readonly PasswordHashing _passHash;
        private readonly LoginRegisterController _logregcontroller;
        public ChangePassword(string Email)
        {
            InitializeComponent();
            DataContext = this;
            _Email = Email;
            _passHash= new PasswordHashing();
            _logregcontroller = new LoginRegisterController();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _oldPassword;
        public string oldPassword
        {
            get => _oldPassword;
            set
            {
                if (value != _oldPassword)
                {
                    _oldPassword = value;
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

        private string _confirmNewPassword;
        public string confirmNewPassword
        {
            get => _confirmNewPassword;
            set
            {
                if (value != _confirmNewPassword)
                {
                    _confirmNewPassword = value;
                    OnPropertyChanged();
                }
            }
        }



        private void PromenaSifre_Button_Click(object sender, RoutedEventArgs e)
        {
           

                if (_logregcontroller.findStudentHash(_Email) != string.Empty)
                {
                    if (_passHash.ValidatePassword(oldPassword, _logregcontroller.findStudentHash(_Email)) == true && newPassword == confirmNewPassword)
                    {
                        string hashedNewPass = _passHash.HashPassword(newPassword);
                        _logregcontroller.changeStudentPassword(_Email, hashedNewPass);
                        Close();
                    }
                    else
                    {
                        WrongPassword wrongPassword = new WrongPassword();
                        wrongPassword.Show();
                    }
                }
                else
                {

                    if (_passHash.ValidatePassword(oldPassword, _logregcontroller.findHash(_Email)) == true && newPassword == confirmNewPassword)
                    {
                        string hashedNewPass = _passHash.HashPassword(newPassword);
                        _logregcontroller.changePassword(_Email, hashedNewPass);
                        Close();
                    }
                    else
                    {
                        WrongPassword wrongPassword = new WrongPassword();
                        wrongPassword.Show();
                    }
                }
            

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            //ReferentUserView rf = new ReferentUserView();
            //rf.Show();
            Close();

        }
    }
}
