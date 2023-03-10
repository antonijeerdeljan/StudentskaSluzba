using Domaci.cs.Controller;
using Domaci.cs.PasswordHashing;
using Front.LoginAndRegistration;
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
    /// Interaction logic for StudentLogin.xaml
    /// </summary>
    public partial class StudentLogin : Window, INotifyPropertyChanged
    {
        private readonly PasswordHashing passHash;
        private readonly LoginRegisterController loginRegisterController;
        public StudentLogin()
        {
            DataContext= this;
            InitializeComponent();
            passHash= new PasswordHashing();
            loginRegisterController = new LoginRegisterController();
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


        
        private void ForgotPassword_TextBox(object sender, RoutedEventArgs e)
        {

            StudentPasswordRecovery rpr = new StudentPasswordRecovery();
            rpr.Show();
            Close();
        }
        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (passHash.ValidatePassword(Password, loginRegisterController.findStudentHash(Email)) == true)
                {
                    loginRegisterController.checkStudentRecovery(Email);
                    StudentView studentview = new StudentView(Email); 
                    studentview.Show();
                    Close();
                }
                else if (passHash.ValidatePassword(Password, loginRegisterController.findStudentRecoveryHash(Email)) == true)
                {
                    NewStudentPassword newpass = new NewStudentPassword(Email, passHash, loginRegisterController);
                    newpass.Show();
                    Close();
                    //nateraj ga na new password
                    //kada napravi new password spakuj kao glavni password
                    //nateraj ga na login
                    //WrongPassword wrongPassword = new WrongPassword();
                    //wrongPassword.Show();


                }
                else
                {
                    WrongPassword wrongPassword = new WrongPassword();
                    wrongPassword.Show();
                    
                }
            }catch (Exception ex)
            {
                WrongPassword wrongPassword = new WrongPassword();
                wrongPassword.Show();
            }
        }
        
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {

            SluzbaWindow main = new SluzbaWindow();
            main.Show();
            Close();
        }



    }
}
