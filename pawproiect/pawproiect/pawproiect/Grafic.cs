using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pawproiect
{
    public class Grafic : Control
    {
        public Grafic()
        {
            Paint += Grafic_Paint;

            KeyDown += Grafic_KeyDown;

            MouseDown += Grafic_MouseDown;

            AllowDrop = true;
            DragEnter += Grafic_DragEnter;
            DragDrop += Grafic_DragDrop;
        }

        private void Grafic_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                string text = (string)e.Data.GetData(typeof(string));
                Valori = text.Split(',').Select(val => int.Parse(val)).ToArray();
            }
        }

        private void Grafic_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {

            }
        }

        private void Grafic_MouseDown(object sender, MouseEventArgs e)
        {
            DataObject dataObject = new DataObject();
            dataObject.SetData(typeof(string), string.Join(",", valori));
            DoDragDrop(dataObject, DragDropEffects.Copy);
        }

        private void Grafic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                int contor = 0;
                PrintDocument document = new PrintDocument();
                document.PrintPage += (s, pea) =>
                {
                    Desenare(pea.Graphics, pea.MarginBounds);
                    contor++;
                    pea.Graphics.DrawString("Pagina " + contor, Font, Brushes.Black, pea.MarginBounds.Location);
                    pea.HasMorePages = contor < 1;
                };
                PrintPreviewDialog dialog = new PrintPreviewDialog();
                dialog.Document = document;
                dialog.ShowDialog();
            }
        }

        public void Grafic_Paint(object sender, PaintEventArgs e)
        {
            Desenare(e.Graphics, DisplayRectangle);
        }

        void Desenare(Graphics g, Rectangle r)
        {
            g.FillRectangle(Brushes.White, r);

            if (Valori.Length == 0)
            {
                return;
            }

            float W = r.Width, H = r.Height;
            int n = valori.Length;
            float w = W / n, f = H * 0.9f / Valori.Max();

            for (int i = 0; i < n; i++)
            {
                float hi = Valori[i] * f;
                RectangleF rElem = new RectangleF(x: i * w + 0.1f * w + r.Left, y: H - hi + r.Top, width: w * 0.8f, height: hi);
                g.FillRectangle(Brushes.Violet, rElem);
                g.DrawRectangle(Pens.Black, Rectangle.Round(rElem));

            }
        }

        int[] valori = new int[0];
        public int[] Valori
        {
            get { return valori; }
            set
            {
                if (value != null)
                {
                    valori = value;
                    Invalidate();
                }
            }
        }
    }
}
