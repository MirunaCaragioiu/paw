using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pawproiect
{
    public class Operatii
    {
        public Operatii(string vandut, string cumparare)
        {
            Vandut = vandut;
            Cumparare = cumparare;
        }

        public string Vandut{get;set;}

        public string Cumparare { get; set; }

    }
}
