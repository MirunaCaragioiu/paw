using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pawproiect
{
    public partial class Form2 : Form
    {
        Stocuri stocuri;
        public Form2(Stocuri stocuri = null)
        {
            InitializeComponent();
            this.stocuri = stocuri;
            if(stocuri!=null)
            {
                textBox1.Text = stocuri.Nume;
                textBox2.Text = stocuri.CantitateS;
                textBox3.Text = stocuri.PretS;

            }
        }

        public Stocuri Rezultat { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (stocuri == null)
                {
                    Rezultat = new Stocuri(textBox1.Text, textBox2.Text, textBox3.Text);
                    FileStream aFile = new FileStream(@"C:\Users\mirun\Desktop\ASE\AN II\sem II\PAW\pawproiect\pawproiect\pawproiect\date.txt", FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(aFile);
                    sw.WriteLine(textBox1.Text);
                    sw.WriteLine(int.Parse(textBox2.Text));
                    sw.WriteLine(int.Parse(textBox3.Text));
                    sw.Close();
                    aFile.Close();
                }
                else
                {
                    stocuri.Nume = textBox1.Text;
                    stocuri.CantitateS = textBox2.Text;
                    stocuri.PretS = textBox3.Text;
                }
                Close();
            }
            catch (FormatException )
            {
                errorProvider1.SetError(textBox2, "Cantitate incorecta!");
            }
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
