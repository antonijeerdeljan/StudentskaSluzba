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
    /// Interaction logic for ReferentRegister.xaml
    /// </summary>
    public partial class ReferentRegister : Window, INotifyPropertyChanged
    {
        private readonly LoginRegisterController _controller;
        private readonly PasswordHashing _passHash;
        public ReferentRegister()
        {
            InitializeComponent();
            DataContext = this;
            _controller = new LoginRegisterController();
            _passHash= new PasswordHashing();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _Ime;
        public string Ime
        {
            get => _Ime;
            set
            {
                if (value != _Ime)
                {
                    _Ime = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Surname;
        public string Surname
        {
            get => _Surname;
            set
            {
                if (value != _Surname)
                {
                    _Surname = value;
                    OnPropertyChanged();
                }
            }
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
        


        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_controller.checkEmail(Email) == false)
            {
                _controller.Register(Ime, Surname, Email, _passHash.HashPassword(Password));
                ReferentLogin reflog = new ReferentLogin();
                Close();
                reflog.Show();
            }
            else
            {
                UsedEmail used = new UsedEmail();
                used.Show();
                
            }
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            ReferentLogin reflog = new ReferentLogin();
            reflog.Show();
            Close();
        }

    }
}
