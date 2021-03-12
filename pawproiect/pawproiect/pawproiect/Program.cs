using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pawproiect
{
    static class Program
    {
        const string CaleFisier = "date3.txt";
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string[] linii = File.ReadAllLines(CaleFisier);
            List<Stocuri> stocuri = new List<Stocuri>();

            int nrStocuri = int.Parse(linii[0]);

            for (int i = 0; i <= nrStocuri-1; i++)
            {
                stocuri.Add(new Stocuri(nume: linii[i*3+1], cantitate: linii[i*3+2], pret: linii[i*3]));
            }
            Application.Run(new Form1(stocuri));
        }
    }
}
