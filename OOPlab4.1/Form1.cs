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
        DoublyLinkedList highlighted = new DoublyLinkedList();
        static Graphics graphics;
        CCircle current = new CCircle();

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            CCircle c = new CCircle(p, r);
            if (!In_any_circle(p))
            {
                if (e.Button == MouseButtons.Left)
                {
                    current = c;
                    circles.Push_back(c);
                    lBcircles.Items.Add(string.Format("{0}, {1}", p.X, p.Y));
                    c.Draw(graphics, 2);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    graphics.Clear(Color.WhiteSmoke);
                    circles = new DoublyLinkedList();
                    lBcircles.Items.Clear();
                }
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    //  should set current to exicting circle and make it red
                }
                else if (e.Button == MouseButtons.Right)
                {
                    //  1) should switch status "highlighted"
                    //  2) should give a color to circle matching to status "highlighted"
                }
            }
        }

        private bool In_any_circle(Point p)
        {
            if (circles.Count > 0)
            {
                circles.Set_current_first();
                for (bool cond = true; cond; cond = circles.Step_forward())
                {
                    CCircle i = (CCircle)circles.Current.Shape.Clone();
                    if (i.Contains(p))
                        return true;
                }
            }
            return false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            graphics = CreateGraphics();
        }
    }
}
