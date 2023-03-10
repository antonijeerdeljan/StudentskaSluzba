using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Domaci.cs.Models;

namespace Domaci.cs.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext()
        {

        }


        public DbSet<StudentPredmet> StudentPredmet { get; set; }
        public DbSet<StudentPPredmet> StudentPPredmet { get; set; }
        public DbSet<StudentNPPredmet> StudentNPPredmet { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Adresa> Adresas { get; set; }
        public DbSet<Profesor> Profesors { get; set; }
        public DbSet<Katedra> Katedras { get; set; }
        public DbSet<Predmet> Predmets { get; set; }
        public DbSet<Ocena> Ocenas { get; set; }
        public DbSet<Referent> Referents { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(e => e.Adresa)
                .WithMany(d => d.Studenti)
                .HasForeignKey(e => e.IDAdresa)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Profesor>()
                .HasOne(e => e.adresa_kancelarije)
                .WithMany(d => d.ProfesoriKanc)
                .HasForeignKey(e => e.adresaKancelarijeID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Profesor>()
                .HasOne(e => e.adresa_stanovanja)
                .WithMany(d => d.ProfesoriKuca)
                .HasForeignKey(e => e.adresaStanovanjaID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Predmet>()
                .HasOne(e => e.profesorPredaje)
                .WithMany(d => d.predajePredmeti)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Predmet>()
                .HasOne(p => p.profesorPredaje)
                .WithMany(p => p.predajePredmeti)
                .HasForeignKey(p => p.ProfesorId)
                .IsRequired(false);

            modelBuilder.Entity<StudentPPredmet>()
                .HasKey(bc => new { bc.StudentId, bc.PredmetId });
            modelBuilder.Entity<StudentPPredmet>()
                .HasOne(bc => bc.Predmet)
                .WithMany(b => b.StudentP)
                .HasForeignKey(bc => bc.PredmetId);
            modelBuilder.Entity<StudentPPredmet>()
                .HasOne(bc => bc.Student)
                .WithMany(c => c.PPredmet)
                .HasForeignKey(bc => bc.StudentId);

            modelBuilder.Entity<StudentNPPredmet>()
                .HasKey(bc => new { bc.StudentId, bc.PredmetId });
            modelBuilder.Entity<StudentNPPredmet>()
                .HasOne(bc => bc.predmet)
                .WithMany(b => b.StudentNP)
                .HasForeignKey(bc => bc.PredmetId);
            modelBuilder.Entity<StudentNPPredmet>()
                .HasOne(bc => bc.student)
                .WithMany(c => c.NPredmet)
                .HasForeignKey(bc => bc.StudentId);


            modelBuilder.Entity<StudentPredmet>()
                .HasKey(bc => new { bc.StudentId, bc.PredmetId });
            modelBuilder.Entity<StudentPredmet>()
                .HasOne(bc => bc.predmet)
                .WithMany(b => b.sviSudenti)
                .HasForeignKey(bc => bc.PredmetId);
            modelBuilder.Entity<StudentPredmet>()
                .HasOne(bc => bc.student)
                .WithMany(c => c.slusaPredmete)
                .HasForeignKey(bc => bc.StudentId);

            modelBuilder.Entity<Ocena>()
                .HasOne(p => p.Student)
                .WithMany(b => b.Ocene);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=OisisiRegistrationV4;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");

            //optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=OISIS2;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");
            //otionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=OISIS2;User ID=DESKTOP-UPD1NNF\\Antonije;Trusted_Connection=True;TrustServerCertificate=True;");


        }
    }
}