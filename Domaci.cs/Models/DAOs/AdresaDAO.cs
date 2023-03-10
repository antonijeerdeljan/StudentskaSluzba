using Domaci.cs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Models.DAOs
{
    public class AdresaDAO
    {
        private readonly List<Adresa> _adresas;
        private readonly DataDbContext db;

        public AdresaDAO()
        {
            db = new DataDbContext();
            _adresas = new List<Adresa>();
            _adresas = db.Adresas.ToList();
        }

        public void Add(string ulica, string broj, string grad, string drzava)
        {
            Adresa adresa = new Adresa();
            adresa.Ulica = ulica;
            adresa.Broj = broj;
            adresa.Grad = grad;
            adresa.Drzava = drzava;
            db.Adresas.Add(adresa);
            db.SaveChanges();
        }

        public void Remove(Adresa adresa)
        {
            _adresas.Remove(adresa);
            db.SaveChanges();
        }
        public List<Adresa> GetAll()
        {
            return _adresas;
        }
    }
}
