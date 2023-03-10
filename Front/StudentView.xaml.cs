using Domaci.cs.Controller;
using Domaci.cs.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class StudentView : Window
    {
        private readonly StudentController studentController;
        public ObservableCollection<Predmet> Nepolozeni { get; set; }
        public ObservableCollection<PolozeniDTO> Polozeni { get; set; }

        private readonly StudentDTO studentdto = new StudentDTO();

        private readonly string emailRet;

        //private readonly Student student;

        public StudentView(string email)
        {
            emailRet = email;
            studentController = new StudentController();
            InitializeComponent();
            Student student = studentController.findStudentByEmail(email);
            studentdto.FirstName = student.Ime;
            studentdto.LastName = student.Prezime;
            studentdto.DatumRodj = student.Datum_Rodjenja.ToString();
            studentdto.AdresaStan = studentController.returnAdress(student);
            studentdto.BrojTel = student.Kontakt_Telefon;
            studentdto.Email = student.E_Mail;
            studentdto.BrojIndeksa = student.Broj_Indeksa;
            studentdto.GodinaUpisa = student.Godina_Upisa.ToString();
            studentdto.TrenuntaGodina = student.Trenunta_Godina.ToString();
            studentdto.Status = studentController.returnStatus(student);

            InitializeComponent();



            FirstName.Content = studentdto.FirstName;
            LastName.Content = studentdto.LastName;
            DatumRodj.Content = studentdto.DatumRodj.ToString();
            AdresaStan.Content = studentdto.AdresaStan;
            BrojTel.Content = studentdto.BrojTel.ToString();
            Email.Content = studentdto.Email.ToString();
            BrojIndeksa.Content = studentdto.BrojIndeksa;
            GodinaUpisa.Content = studentdto.GodinaUpisa;
            TrenutnaGodina.Content = studentdto.TrenuntaGodina;
            Status.Content = studentdto.Status;

            //AdresaStan.Content = student.Adresa_Stan
            //Status


            Nepolozeni = new ObservableCollection<Predmet>(studentController.nepolozeniPredemti(student));
            Polozeni = new ObservableCollection<PolozeniDTO>(studentController.getAllPolozeni(student));
            DataContext = this;

        }




        private void LogOut_Button_Click(object sender, RoutedEventArgs e)
        {
            SluzbaWindow sluzbaWindow = new SluzbaWindow();
            sluzbaWindow.Show();
            Close();
        }

        

        private void ChangePassword_Button_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword changePassView = new ChangePassword(emailRet);
            changePassView.Show();
            
        }
    }
}
