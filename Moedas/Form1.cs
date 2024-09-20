using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moedas
{
    public partial class Numismata : Form
    {
        public Numismata()
        {
            InitializeComponent();
        }

        private const int CS_DropShadow = 0x00020000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = CS_DropShadow;
                return cp;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                var p = new Pen(Color.Red, 3);
                var point1 = new Point(1, 0);
                var point2 = new Point(panel1.Width, panel1.Height);
                g.DrawLine(p, point2, point1);
            }
        }

        private void txbPesquisa_Enter(object sender, EventArgs e)
        {
            if (txbPesquisa.Text == " Pesquisar")
            {
                txbPesquisa.Text = "";

                txbPesquisa.ForeColor = Color.Black;
            }
        }

        private void txbPesquisa_Leave(object sender, EventArgs e)
        {
            if (txbPesquisa.Text == "")
            {
                txbPesquisa.Text = " Pesquisar";

                txbPesquisa.ForeColor = Color.Silver;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInserirDados_Click(object sender, EventArgs e)
        {
            Nada nada = new Nada();
            try
            {
                using (InserirDados uu = new InserirDados())
                {
                    nada.StartPosition = FormStartPosition.Manual;
                    nada.FormBorderStyle = FormBorderStyle.None;
                    nada.Opacity = .80d;
                    nada.BackColor = Color.Black;
                    nada.WindowState = FormWindowState.Maximized;
                    nada.TopMost = true;
                    nada.Location = this.DesktopLocation;
                    nada.ShowInTaskbar = false;
                    nada.Show();

                    uu.Owner = nada;
                    uu.ShowDialog();

                    nada.Dispose();
                }
            }
            catch (Exception ex) { }
            finally
            {
                nada.Dispose();
            }
        }
    }
}
