using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pawproiect
{
    public class Stocuri
    { string cantitateS;
        int cantitate;
        int pret;
        string pretS;
       /* public Stocuri(string nume, int cantitate, int pret)
        {
            Nume = nume;
            Cantitate = cantitate;
           Pret = pret;
        }*/
        public Stocuri(string nume,string cantitate,string pret)
        {
            Nume = nume;
            cantitateS = cantitate;
            pretS = pret;
        }
        public string CantitateS { get { return cantitateS; } set { cantitateS = value; Cantitate = int.Parse(cantitateS); } }
        public string Nume { get; set; }
        public int Cantitate { get { return cantitate; } set { cantitate = int.Parse(cantitateS); } }
        public string PretS { get { return pretS; } set { pretS = value;  Pret = int.Parse(pretS); } }
        public int Pret { get { return pret; } set { pret = int.Parse(pretS); } }

        public override string ToString()
        {
            return $"{Nume}, {Cantitate}, {Pret}";
        }
    }
}
