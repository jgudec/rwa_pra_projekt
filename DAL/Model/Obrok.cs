using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Obrok
    {
        public int IDObrok { get; set; }
        public string Naziv { get; set; }
        public bool Dostupan { get; set; }
    }
}
