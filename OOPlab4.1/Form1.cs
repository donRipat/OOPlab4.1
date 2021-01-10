using System;
using System.Drawing;
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
        StatusCircle cur;
        static Graphics graphics;
        
        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            if (!In_any_circle(p))
            {
                //  mouse down on form
                if (e.Button == MouseButtons.Left)
                {
                    //  redraw old circle
                    if (circles.Search(cur))
                    {
                        circles.Current.Shape.Switch_current();
                        circles.Current.Shape.Draw(graphics);
                    }

                    //  adding new circle
                    cur = new StatusCircle(p, r);
                    cur.Draw(graphics);
                    circles.Push_back(cur);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    bool h = false;
                    //  h turns to TRUE if list contained highlighted circles

                    bool c = false;
                    //  c turns to TRUE if current was deleted

                    //  deleting circles
                    if (circles.Count > 0)
                    {
                        circles.Set_current_first();
                        for (bool cond = !circles.Is_empty(); cond; )
                        {
                            if (circles.Current != null)
                            {
                                StatusCircle t = (StatusCircle)circles.Current.Shape;
                                if (t.Status == 1 || t.Status == 3)
                                {
                                    h = true;
                                    if (t.Status == 3)
                                        c = true;
                                    if (t != circles.Head.Shape)
                                    {
                                        circles.Delete_current();
                                        cond = circles.Step_forward();
                                    }
                                    else
                                    {
                                        circles.Delete_current();
                                        cond = !circles.Is_empty();
                                    }
                                }
                                else
                                    cond = circles.Step_forward();
                            }
                        }
                        if (c)
                        {
                            cur = null;
                            if (circles.Count > 0)
                            {
                                circles.Tail.Shape.Switch_current();
                                cur = (StatusCircle)circles.Tail.Shape;
                            }
                        }
                        else if (circles.Count > 0 && !h)
                        {
                            if (circles.Search(cur))
                                circles.Delete_current();
                            cur = null;
                            if (circles.Count > 0)
                            {
                                circles.Tail.Shape.Switch_current();
                                cur = (StatusCircle)circles.Tail.Shape;
                            }
                        }
                    }
                    Draw_frm();
                }
            }
            else
            {
                //  mouse down on circle
                if (e.Button == MouseButtons.Left)
                {
                    StatusCircle c = In_which_circle(p);

                    //  redraw old circle
                    if (circles.Search(cur))
                        circles.Current.Shape.Switch_current();
                    circles.Current.Shape.Draw(graphics);

                    //  redraw new current
                    if (circles.Search(c))
                        circles.Current.Shape.Switch_current();
                    cur = (StatusCircle)circles.Current.Shape;
                    cur.Draw(graphics);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    Highlight(p);
                    Draw_frm();
                }
            }

            lBcircles.Items.Clear();
            circles.Set_current_first();
            for (bool cond = !circles.Is_empty(); cond; cond = circles.Step_forward())
            {
                StatusCircle c = (StatusCircle)circles.Current.Shape;
                lBcircles.Items.Add(string.Format("{0}, {1}",
                    c.X, c.Y));
            }
        }

        // ================================================
        // ================================================
        
            /// There's some problems with deleting highlighted objects
            /// but other things' fine
        
        // ================================================
        // ================================================

        private bool In_any_circle(Point p)
        {
            bool ans = false;
            if (circles.Count > 0)
            {
                circles.Set_current_first();
                for (bool cond = !circles.Is_empty(); cond; cond = circles.Step_forward())
                {
                    if (circles.Current.Shape.Contains(p))
                        ans = true;
                }
            }
            return ans;
        }

        private StatusCircle In_which_circle(Point p)
        {
            if (circles.Count > 0)
            {
                circles.Set_current_first();
                for (bool cond = !circles.Is_empty(); cond; cond = circles.Step_forward())
                {
                    if (circles.Current.Shape.Contains(p))
                        return (StatusCircle)circles.Current.Shape;
                }
            }
            return null;
        }

        private void Highlight(Point p)
        {
            if (circles.Count > 0)
            {
                circles.Set_current_first();
                for (bool cond = !circles.Is_empty(); cond; cond = circles.Step_forward())
                {
                    if (circles.Current.Shape.Contains(p))
                        circles.Current.Shape.Switch_highlight();
                }
            }
        }
        
        private void Draw_frm()
        {
            graphics.Clear(Color.WhiteSmoke);
            circles.Set_current_first();
            for (bool cond = !circles.Is_empty(); cond; cond = circles.Step_forward())
            {
                circles.Current.Shape.Draw(graphics);
            }
            if (cur != null)
                cur.Draw(graphics);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            graphics = CreateGraphics();
        }
    }
}
