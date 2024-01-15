using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace gdi_PointAndClick
{
    public partial class FrmMain : Form
    {
        private List<Rectangle> rectangles = new List<Rectangle>();
        private Random random = new Random();

        public FrmMain()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush b;

            foreach (Rectangle rect in rectangles)
            {
                b = new SolidBrush(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
                g.FillRectangle(b, rect);
            }
        }

        private void FrmMain_MouseClick(object sender, MouseEventArgs e)
        {
            Point mousePosition = e.Location;

            if (!IsPointInsideRectangles(mousePosition))
            {
                int size = random.Next(20, 100);
                int halfSize = size / 2;

                Rectangle newRect = new Rectangle(mousePosition.X - halfSize, mousePosition.Y - halfSize, size, size);
                rectangles.Add(newRect);

                Refresh();
            }
        }

        private bool IsPointInsideRectangles(Point point)
        {
            foreach (Rectangle rect in rectangles)
            {
                if (rect.Contains(point))
                {
                    return true;
                }
            }
            return false;
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                rectangles.Clear();
                Refresh();
            }
        }
    }
}
