using Domaci.cs.Models;
using Domaci.cs.Models.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Controller
{
    public class KatedraController
    {
        private readonly KatedraDAO _katedre;
        public KatedraController()
        {
            _katedre = new KatedraDAO();
        }
        public void createKatedra(int sifra, string naziv, string sef)
        {
            _katedre.createKatedra(sifra, naziv, sef);
        }

        public List<Katedra> GetAllKatedre()
        {
            return _katedre.GetAll();
        }

        public void setSefKatedre(Katedra ktd, string prof)
        {
            _katedre.setSefKatedre(ktd, prof);
        }
    }
}
