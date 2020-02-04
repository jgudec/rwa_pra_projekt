using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Korisnik
    {
        public int IDKorisnik { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DOB { get; set; }
        public char Spol { get; set; }
        public int TipDijabetesa { get; set; }
        public int FizickaAktivnost { get; set; }
        public double Visina { get; set; }
        public double Tezina { get; set; }
        public double BMI { get; set; }
    }
}
