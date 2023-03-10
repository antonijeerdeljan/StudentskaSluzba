using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci.cs.Models
{
    public class Referent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public bool IsPasswordForgotten { get; set; } = false;
        public string TempPassword { get; set; } = string.Empty;

        //public string Kontakt_Telefon { get; set; }


    }
}
