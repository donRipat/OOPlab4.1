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
        CCircle newcurrent = new CCircle();

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            if (!In_any_circle(p))
            {
                //  mouse down on form
                CCircle c = new CCircle(p, r);
                if (e.Button == MouseButtons.Left)
                {
                    //  adding new circle
                    if (newcurrent != null)
                        newcurrent.Draw(graphics, 0);
                    current = c;
                    newcurrent = c;
                    circles.Push_back(c);
                    lBcircles.Items.Add(string.Format("{0}, {1}", p.X, p.Y));
                    newcurrent.Draw(graphics, 2);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    //  deleting all circles
                    graphics.Clear(Color.WhiteSmoke);
                    lBcircles.Items.Clear();
                    if (highlighted.Count == 0)
                        circles = new DoublyLinkedList();
                    else 
                    {
                        while (highlighted.Count > 0)
                        {
                            for (circles.Set_current_first();
                                highlighted.Head != circles.Current;
                                circles.Step_forward())
                                ;   //  EMPTY CYCLE
                            circles.Delete_current();
                            highlighted.Delete_first();
                        }
                    }
                    current = null;
                    newcurrent = null;
                }
            }
            else
            {
                //  mouse down on circle
                if (e.Button == MouseButtons.Left)
                {
                    current.Draw(graphics, 0);
                    newcurrent.Draw(graphics, 2);
                    current = newcurrent;
                    //  should set current to exicting circle and make it red
                }
                else if (e.Button == MouseButtons.Right)
                {
                    current = null;
                    Draw_group(1);
                    //  1) should switch status "highlighted"
                    //  2) should give a color to circle matching to status "highlighted"
                }
            }
        }

        private bool In_any_circle(Point p)
        {
            bool ans = false;
            if (circles.Count > 0)
            {
                circles.Set_current_first();
                for (bool cond = true; cond; cond = circles.Step_forward())
                {
                    CCircle i = (CCircle)circles.Current.Shape.Clone();
                    if (i.Contains(p))
                    {
                        newcurrent = i;
                        highlighted.Push_back(i);
                        ans = true;
                    }
                }
            }
            return ans;
        }

        private void Draw_group(int status)
        {
            highlighted.Set_current_first();
            for (bool cond = true; cond; cond = highlighted.Step_forward())
            {
                highlighted.Current.Shape.Draw(graphics, status);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            graphics = CreateGraphics();
        }
    }
}
