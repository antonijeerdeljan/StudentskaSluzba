global using System;
using Domaci.cs.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;




namespace Domaci.cs
{
    class Program 
    {
        static void Main()
        {
            //MainWindow mainWindow = new MainWindow();
            ///////////Ovaj deo je potrebno zakomentarisati ukoliko baza nije instalirana !!!
            using var db = new DataDbContext();
            db.Database.EnsureCreated();
            /////////////////////////////////////////////////////////////////////////////////
            //ManagerConsoleView managerConsoleView = new ManagerConsoleView();
            //managerConsoleView.RunMenu();

        }

    }
}