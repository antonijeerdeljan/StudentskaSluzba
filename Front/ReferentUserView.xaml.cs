using Domaci.cs.Controller;
using Domaci.cs.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Domaci.cs.Models;
using System.ComponentModel;
using Domaci;
using Domaci.cs.Observers;
using System.Windows.Threading;


namespace Front
{
    /// <summary>
    /// Interaction logic for ReferentUserView.xaml
    /// </summary>
    public partial class ReferentUserView : Window, IObserver
    {
        private readonly StudentController _stdController;
        private readonly PredmetController _prdController;
        private readonly ProfesorController _prfController;
        private readonly String _Email;

        public ObservableCollection<Profesor> Profesors { get; set; }
        public ObservableCollection<Student> Students { get; set; }
        public ObservableCollection<Predmet> Predmets { get; set; }


        public Profesor SelectedProfesors { get; set; }
        public Student SelectedStudent { get; set; }
        public Predmet SelectedPredmets { get; set; }



        public ReferentUserView(string Email)
        {
            InitializeComponent();
            DataContext = this;
            _stdController = new StudentController();
            _prdController = new PredmetController();
            _prfController = new ProfesorController();
            _Email = Email;



            _stdController.Subscribe(this);
            _prdController.Subscribe(this);
            _prfController.Subscribe(this);

            Students = new ObservableCollection<Student>(_stdController.GetAllStudents());
            Predmets = new ObservableCollection<Predmet>(_prdController.GetAllPredmet());
            Profesors = new ObservableCollection<Profesor>(_prfController.GetAllProfesors());

        }

        private void UpdateText(object sender, SelectionChangedEventArgs e)
        {
            if (TabStudent.IsSelected)
                textUpdateTab.Text = "  Studenti";

            else if (TabProfesor.IsSelected)
                textUpdateTab.Text = "  Profesori";

            else if (TabPredmet.IsSelected)
                textUpdateTab.Text = "  Predmeti";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, (object s, EventArgs ev) =>
            {
                this.myDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            }, this.Dispatcher);
            timer.Start();

        }


        private void AddWindow_click(object sender, RoutedEventArgs e)
        {
            if (TabStudent.IsSelected)
            {
                Dodaj_studenta window = new Dodaj_studenta(_stdController);
                window.Show();
            }
            else if (TabPredmet.IsSelected)
            {
                Dodaj_predmet window = new Dodaj_predmet(_prdController);
                window.Show();

            }
            else if (TabProfesor.IsSelected)
            {
                Profesor profa = new Profesor();
                profa = SelectedProfesors;
                Dodaj_profesora window = new Dodaj_profesora(_prfController);
                window.Show();

            }
        }

        private void deleteWindow_click(object sender, RoutedEventArgs e)
        {
            if (TabStudent.IsSelected && SelectedStudent != null)
            {
                Brisanje_studenta window = new Brisanje_studenta(_stdController, SelectedStudent);
                window.Show();
            }

            else if (TabPredmet.IsSelected && SelectedPredmets != null)
            {
                Brisanje_predmeta window = new Brisanje_predmeta(_prdController, SelectedPredmets);
                window.Show();
            }

            else if (TabProfesor.IsSelected && SelectedProfesors != null)
            {
                BrisanjeProfesora window = new BrisanjeProfesora(_prfController, SelectedProfesors);
                window.Show();
            }

        }

        private void About_window(object sender, RoutedEventArgs e)
        {
            About window = new About();
            window.Show();
        }


        private void IzmeniWindow_click(object sender, RoutedEventArgs e)
        {
            if (TabStudent.IsSelected && SelectedStudent != null)
            {
                Izmena_studenta window = new Izmena_studenta(_stdController, SelectedStudent, _prdController);
                window.Show();
            }

            else if (TabProfesor.IsSelected && SelectedProfesors != null)
            {
                IzmenaProfesora window = new IzmenaProfesora(_prfController, _prdController, SelectedProfesors);
                window.Show();
            }

            else if (TabPredmet.IsSelected && SelectedPredmets != null)
            {
                Izmena_predmeta window = new Izmena_predmeta(_prdController, _prfController, SelectedPredmets);
                window.Show();
            }
        }





        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (TabStudent.IsSelected)
            {
                Dodaj_studenta window = new Dodaj_studenta(_stdController);
                window.Show();
            }
            else if (TabPredmet.IsSelected)
            {
                Dodaj_predmet window = new Dodaj_predmet(_prdController);
                window.Show();

            }
            else if (TabProfesor.IsSelected)
            {
                Dodaj_profesora window = new Dodaj_profesora(_prfController);
                window.Show();
            }
        }



        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (TabStudent.IsSelected && SelectedStudent != null)
            {
                Izmena_studenta window = new Izmena_studenta(_stdController, SelectedStudent, _prdController);
                window.Show();
            }
            else if (TabPredmet.IsSelected)
            {
                Dodaj_predmet window = new Dodaj_predmet(_prdController);
                window.Show();

            }
            else if (TabProfesor.IsSelected)
            {
                Dodaj_profesora window = new Dodaj_profesora(_prfController);
                window.Show();
            }


            else if (TabProfesor.IsSelected && SelectedProfesors != null)
            {
                IzmenaProfesora window = new IzmenaProfesora(_prfController, _prdController, SelectedProfesors);
                window.Show();
            }


        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            ReferentLogin reflog = new ReferentLogin();
            Close();
            reflog.Show();
        }

        


        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            Profile prof = new Profile(_Email);
            prof.Show();
        }



        private void KatedrasButton_Click(object sender, RoutedEventArgs e)
        {
            Napravi_Katedru m = new Napravi_Katedru();
            m.Show();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TabStudent.IsSelected && SelectedStudent != null)
            {
                Brisanje_studenta window = new Brisanje_studenta(_stdController, SelectedStudent);
                window.Show();
            }

            else if (TabPredmet.IsSelected && SelectedPredmets != null)
            {
                Brisanje_predmeta window = new Brisanje_predmeta(_prdController, SelectedPredmets);
                window.Show();
            }

            else if (TabProfesor.IsSelected && SelectedProfesors != null)
            {
                BrisanjeProfesora window = new BrisanjeProfesora(_prfController, SelectedProfesors);
                window.Show();
            }

        }



        private void Execute_command(object sender, ExecutedRoutedEventArgs e)
        {
            System.Console.WriteLine("Not a valid number, try again: ");
        }

        private void Application_Exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();

        }





        private void UpdateStudentsList()
        {
            Students.Clear();

            foreach (var student in _stdController.GetAllStudents())
            {
                Students.Add(student);
            }

        }
        private void UpdatePredmetList()
        {
            Predmets.Clear();

            foreach (var predmet in _prdController.GetAllPredmet())
            {
                Predmets.Add(predmet);
            }

        }

        private void UpdateProfesorsList()
        {
            Profesors.Clear();
            foreach (var prof in _prfController.GetAllProfesors())
            {
                Profesors.Add(prof);
            }

        }

        public void Update()
        {
            UpdateStudentsList();

            UpdatePredmetList();

            UpdateProfesorsList();

        }


    }
}