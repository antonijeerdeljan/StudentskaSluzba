using Domaci.cs.Controller;
using Domaci.cs.Models;
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
    /// Interaction logic for Unos_ocene.xaml
    /// </summary>
    public partial class Unos_ocene : Window, INotifyPropertyChanged
    {
        private readonly StudentController studentController;
        private readonly Predmet Predmet;
        private readonly Student Student;
        public Unos_ocene(Predmet predmet,StudentController stdController, Student student)
        {
            studentController = stdController; 
            Student = student;
            Predmet = predmet;
            InitializeComponent();
            DataContext = this;

            Sifra_predmeta = predmet.Sifra_predmeta.ToString();
            Naziv_predmeta = predmet.Naziv_predmeta;

        }

        private string _Sifra_predmeta;
        public string Sifra_predmeta
        {
            get => _Sifra_predmeta;
            set
            {
                if (value != _Sifra_predmeta)
                {
                    _Sifra_predmeta = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Naziv_predmeta;
        public string Naziv_predmeta
        {
            get => _Naziv_predmeta;
            set
            {
                if (value != _Naziv_predmeta)
                {
                    _Naziv_predmeta = value;
                    OnPropertyChanged();
                }
            }
        }




        private string _Upisana_Ocena;
        public string Upisana_Ocena
        {
            get => _Upisana_Ocena;
            set
            {
                if (value != _Upisana_Ocena)
                {
                    _Upisana_Ocena = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Datum_Polaganja;
        public string Datum_Polaganja
        {
            get => _Datum_Polaganja;
            set
            {
                if (value != _Datum_Polaganja)
                {
                    _Datum_Polaganja = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            studentController.upisiOcenu(Student,Predmet, Upisana_Ocena, Datum_Polaganja);
            Close();
        }
    }
}
