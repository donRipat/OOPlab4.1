using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOPlab4._1
{
    class CCircle: AShape
    {
        private int x;
        private int y;
        private int r;

        public CCircle()
        {
            x = 0;
            y = 0;
            r = 0;
        }
        public CCircle(int x, int y, int r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }
        public CCircle(Point p, int r)
        {
            x = p.X;
            y = p.Y;
            this.r = r;
        }
        public CCircle(ref CCircle c)
        {
            x = c.x;
            y = c.y;
            r = c.r;
        }

        public int R { get => r; }
        public int X { get => x; }
        public int Y { get => y; }

        //  "Draw"
        public override void Draw(Graphics g, int statement)
        {
            int x = this.x - r / 2;
            int y = this.y - r / 2;
            Pen pen;
            int w = 2;
            if (statement == 2)
                pen = new Pen(Color.Red, w);
            else if (statement == 1)
                pen = new Pen(Color.Blue, w);
            else
                pen = new Pen(Color.Purple, w);
            g.DrawEllipse(pen, x, y, r, r);
        }

        public bool Contains(Point p)
        {
            if (p != null)
                if (Math.Sqrt((p.X - x) * (p.X - x) + (p.Y - y) * (p.Y - y)) < r / 2)
                    return true;
            return false;
        }

        public override AShape Clone()
        {
            return new CCircle(x, y, r);
        }
    }
}
