using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public override void Draw()
        {
            
        }

        public override AShape Clone()
        {
            return new CCircle(x, y, r);
        }
    }
}
