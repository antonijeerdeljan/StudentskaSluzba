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
using Domaci.cs.Controller;

namespace Front
{
    /// <summary>
    /// Interaction logic for Dodaj_profesora.xaml
    /// </summary>
    public partial class Dodaj_profesora : Window, INotifyPropertyChanged
    {
        private readonly ProfesorController _profController;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }








        //imeProf prezimeProf zvanjeProf emailProf




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



        private string _adresaKancelarije;
        public string adresaKancelarije
        {
            get => _adresaKancelarije;
            set
            {
                if (value != _adresaKancelarije)
                {
                    _adresaKancelarije = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Telefon;
        public string Telefon
        {
            get => _Telefon;
            set
            {
                if (value != _Telefon)
                {
                    _Telefon = value;
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

        private string _Zvanje;
        public string Zvanje
        {
            get => _Zvanje;
            set
            {
                if (value != _Zvanje)
                {
                    _Zvanje = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _brojLicne;
        public int brojLicne
        {
            get => _brojLicne;
            set
            {
                if (value != _brojLicne)
                {
                    _brojLicne = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _godineStaza;
        public int godineStaza
        {
            get => _godineStaza;
            set
            {
                if (value != _godineStaza)
                {
                    _godineStaza = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _TrenutnaGodStud;
        public int TrenutnaGodStud
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


        private string _Katedra;
        public string Katedra
        {
            get => _Katedra;
            set
            {
                if (value != _Katedra)
                {
                    _Katedra = value;
                    OnPropertyChanged();
                }
            }
        }


        private DateTime _DatumRodj;
        public DateTime DatumRodj
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


        public Dodaj_profesora(ProfesorController profControl)
        {
            InitializeComponent();
            DataContext = this;
            _profController = profControl;
            KatedraController ktdcontrol = new KatedraController();
            List<String> imena = new List<String>();
            foreach(var ktd in ktdcontrol.GetAllKatedre())
            {
                imena.Add(ktd.Naziv_Katedre);
            }
            Combobox.ItemsSource = imena;

        }

        private void CancelButton_clock(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender,RoutedEventArgs e)
        {
            _profController.Create(FirstName,LastName, DatumRodj, AdresaStan, adresaKancelarije, Telefon, Email, brojLicne, Zvanje, godineStaza, Katedra);
            Close();
        }
    }
}


