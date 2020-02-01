using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Namirnica
    {
        public int IDNamirnica { get; set; }

        public string Naziv { get; set; }

        public string tipNamirnice { get; set; }

        public int Kcal { get; set; }
        public int Kj { get; set; }
    }
}
