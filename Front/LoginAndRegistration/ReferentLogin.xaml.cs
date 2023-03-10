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
using MailKit.Net.Smtp;
using MimeKit;
using MailKit;


namespace Front
{
    /// <summary>
    /// Interaction logic for ReferentLogin.xaml
    /// </summary>
    public partial class ReferentLogin : Window, INotifyPropertyChanged
    {
        private readonly LoginRegisterController _logregController;
        private readonly PasswordHashing _passHash; 
        public ReferentLogin()
        {
            InitializeComponent();
            _logregController = new LoginRegisterController();
            _passHash = new PasswordHashing();
            DataContext = this;
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

        private string _Password;

        public string Password
        {
            get => _Password;
            set
            {
                if (value != _Password)
                {
                    _Password = value;
                    OnPropertyChanged();
                }
            }
        }


        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_passHash.ValidatePassword(Password, _logregController.findHash(Email)) == true)
                {
                    _logregController.checkRecovery(Email);
                    ReferentUserView refview = new ReferentUserView(Email);
                    Close();
                    refview.Show();
                }
                else if (_passHash.ValidatePassword(Password, _logregController.findRecoveryHash(Email)) == true)
                {
                    NewPassword newpass = new NewPassword(Email, _passHash, _logregController);
                    newpass.Show();
                    //nateraj ga na new password
                    //kada napravi new password spakuj kao glavni password
                    //nateraj ga na login
                    //WrongPassword wrongPassword = new WrongPassword();
                    //wrongPassword.Show();


                }
            }catch(Exception ex)
            {
                WrongPassword wrongPassword = new WrongPassword();
                wrongPassword.Show();
            }
            
        }




        private void ForgotPassword_TextBox(object sender, RoutedEventArgs e)
        {

            ReferentPasswordRecovery rpr = new ReferentPasswordRecovery();
            rpr.Show();
            Close();
        }


        private void Register_TextBox(object sender, RoutedEventArgs e)
        {
            ReferentRegister reg = new ReferentRegister();
            reg.Show();
            Close();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            SluzbaWindow main = new SluzbaWindow();
            main.Show();
            Close();
        }

    }
}
