using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pawproiect
{
    public partial class Form1 : Form
    {
        List<Stocuri> stocuri;
        public Form1(List<Stocuri> stocuri)
        {
            InitializeComponent();

            this.stocuri = stocuri;

            listView1.View = View.Details;
            listView1.Columns.Add("Nume", 250);
            listView1.Columns.Add("Cantitate", 150);
            listView1.Columns.Add("Pret", 140);

            listView1.MultiSelect = false;
            listView1.FullRowSelect = true;

            Afisare();
        }
        private void Afisare()
        {
            listView1.Items.Clear();
            foreach (Stocuri stocuri in stocuri.OrderByDescending(s => s.Pret))
            {
                ListViewItem rand = new ListViewItem();
                rand.Text = stocuri.Nume;
                rand.SubItems.Add(stocuri.CantitateS);
                rand.SubItems.Add(stocuri.PretS);
                listView1.Items.Add(rand);
            }
        }

        private void adaugaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            stocuri.Add(form.Rezultat);
            Afisare();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();
            Afisare();
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
