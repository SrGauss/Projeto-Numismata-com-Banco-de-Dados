using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moedas
{
    public class DiagonalSeparator : UserControl
    {
        private int thickness = 3;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                var p = new Pen(ForeColor, thickness);
                var point1 = RightToLeft == RightToLeft.No ? new Point(0, 0) : new Point(Width, 0);
                var point2 = RightToLeft == RightToLeft.No ? new Point(Width, Height) : new Point(0, Height);
                g.DrawLine(p, point1, point2);
            }
        }

        [DefaultValue(3)]
        [Description("The thickness of the drawn line"), Category("Appearance")]
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Thickness
        {
            get
            {
                return thickness;
            }

            set
            {
                thickness = value;
                Invalidate();
            }
        }
    }
}
