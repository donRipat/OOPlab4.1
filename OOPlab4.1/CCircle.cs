using System;
using System.Drawing;
using System.Diagnostics;

namespace OOPlab4._1
{
    class CCircle: AShape
    {
        Point center;
        private int r;

        public CCircle()
        {
            center = new Point();
            r = 0;
        }
        public CCircle(int x, int y, int r)
        {
            center = new Point(x, y);
            this.r = r;
        }
        public CCircle(Point p, int r)
        {
            center = new Point(p.X, p.Y);
            this.r = r;
        }
        public CCircle(CCircle c)
        {
            center = new Point(c.X, c.Y);
            r = c.R;
        }

        public int R { get => r; }
        public int X { get => center.X; }
        public int Y { get => center.Y; }
        public Point Center { get => center; }

        //  "Draw"
        public override void Draw(Graphics g)
        {
            Debug.WriteLine("O");
        }
        
        public override bool Contains(Point p)
        {
            if (p != null)
                if (Math.Sqrt((p.X - center.X) * (p.X - center.X) + 
                    (p.Y - center.Y) * (p.Y - center.Y)) < r / 2)
                    return true;
            return false;
        }

        public override void Switch_current() { }
        public override void Switch_highlight() { }
    }
    
    class StatusCircle : CCircle
    {
        private int status;
        //  3 - current highlighted
        //  2 - current
        //  1 - highlighted
        //  0 - default

        public StatusCircle(): base()
        {
            status = 2;
        }

        public StatusCircle(Point p, int r): base(p, r)
        {
            status = 2;
        }

        public StatusCircle(int st, Point center, int rad): base(center, rad)
        {
            status = st;
        }

        public StatusCircle(int st, int x, int y, int rad): base(x, y, rad)
        {
            status = st;
        }

        public StatusCircle(StatusCircle t): base(t)
        {
            status = t.Status;
        }

        public override void Draw(Graphics g)
        {
            int x = X - R / 2;
            int y = Y - R / 2;
            Pen pen;
            int w = 5;
            if (status == 3)
                pen = new Pen(Color.Red, w);
            else if (status == 2)
                pen = new Pen(Color.Orange, w);
            else if (status == 1)
                pen = new Pen(Color.Blue, w);
            else
                pen = new Pen(Color.SeaGreen, w);
            g.DrawEllipse(pen, x, y, R, R);
        }
        
        public override void Switch_current()
        {
            if (status > 1)
                status -= 2;
            else status += 2;
        }

        public override void Switch_highlight()
        {
            if (status == 1 || status == 3)
                --status;
            else ++status;
        }

        public int Status { get => status; }
    }
}
