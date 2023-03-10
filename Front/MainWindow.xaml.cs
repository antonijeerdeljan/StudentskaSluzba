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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SluzbaWindow sluzba = new SluzbaWindow();
            sluzba.Show();
            Close();
        }

        


    }
}
