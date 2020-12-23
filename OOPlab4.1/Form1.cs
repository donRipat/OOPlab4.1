using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPlab4._1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        const int r = 75;
        DoublyLinkedList circles = new DoublyLinkedList();

        private void frmMain_Load(object sender, EventArgs e)
        {
            Graphics fMain = this.CreateGraphics();
        }

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            if (May_add(x, y))
            {
                CCircle c = new CCircle(x, y, r);
                circles.Push_back(c);
                lBcircles.Items.Add(string.Format("{0}, {1}", x, y));
                x -= r / 2;
                y -= r / 2;
                Draw(true, x, y);
            }
        }

        private void Draw(bool sel, int x, int y)
        {
            Graphics graphics = CreateGraphics();
            if (sel)
                graphics.FillEllipse(Brushes.DarkViolet, x, y, r, r);
            else
                graphics.FillEllipse(Brushes.Blue, x, y, r, r);
            graphics.Dispose();
        }

        private bool May_add(int x, int y)
        {
            if (circles.Count > 0)
            {
                circles.Set_current_first();
                for (bool cond = true; cond; cond = circles.Step_forward())
                {
                    CCircle i = (CCircle)circles.Current.Shape.Clone();
                    if (Math.Sqrt((i.X - x) * (i.X - x) + (i.Y - y) * (i.Y - y)) < r / 2)
                        return false;
                }
            }
            return true;
        }
    }
}
