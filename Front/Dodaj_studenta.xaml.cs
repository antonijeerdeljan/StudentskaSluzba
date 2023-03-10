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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Front
{
    /// <summary>
    /// Interaction logic for Dodaj_studenta.xaml
    /// </summary>
    public partial class Dodaj_studenta : Window, INotifyPropertyChanged
    {
        private readonly StudentController _studentController;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _index;
        public string Index
        {
            get => _index;
            set
            {
                if (value != _index)
                {
                    _index = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _FirstName;
        public string FirstName
        {
            get => _FirstName;
            set
            {
                if (value != _FirstName)
                {
                    _FirstName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _LastName;
        public string LastName
        {
            get => _LastName;
            set
            {
                if (value != _LastName)
                {
                    _LastName = value;
                    OnPropertyChanged();
                }
            }
        }



        private string _DatumRodj;
        public string DatumRodj
        {
            get => _DatumRodj;
            set
            {
                if (value != _DatumRodj)
                {
                    _DatumRodj = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _AdresaStan;
        public string AdresaStan
        {
            get => _AdresaStan;
            set
            {
                if (value != _AdresaStan)
                {
                    _AdresaStan = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _BrojTel;
        public string BrojTel
        {
            get => _BrojTel;
            set
            {
                if (value != _BrojTel)
                {
                    _BrojTel = value;
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

        private string _BrojIndeksa;
        public string BrojIndeksa
        {
            get => _BrojIndeksa;
            set
            {
                if (value != _BrojIndeksa)
                {
                    _BrojIndeksa = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _GodinaUpisa;
        public string GodinaUpisa
        {
            get => _GodinaUpisa;
            set
            {
                if (value != _GodinaUpisa)
                {
                    _GodinaUpisa = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _TrenutnaGodStud;
        public string TrenutnaGodStud
        {
            get => _TrenutnaGodStud;
            set
            {
                if (value != _TrenutnaGodStud)
                {
                    _TrenutnaGodStud = value;
                    OnPropertyChanged();
                }
            }
        }





        private string _NacinFin;
        public string NacinFin
        {
            get => _NacinFin;
            set
            {
                if (value != _NacinFin)
                {
                    _NacinFin = value;
                    OnPropertyChanged();
                }
            }
        }


        public Dodaj_studenta(StudentController studentController)
        {
            InitializeComponent();
            DataContext = this;
            _studentController = studentController;

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_studentController.checkEmail(Email) == false)
            {
                _studentController.Create(LastName, FirstName, DatumRodj, AdresaStan, BrojTel, Email, BrojIndeksa, GodinaUpisa, TrenutnaGodStud, NacinFin);
                Close();
            }
            else
            {
                UsedEmail usedEmail = new UsedEmail();
                usedEmail.Show();
            }
        }
    }
}
