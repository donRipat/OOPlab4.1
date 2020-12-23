using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOPlab4._1
{
    abstract class AShape
    {
        public abstract void Draw(Graphics g, int statement);
        public abstract AShape Clone();
    }
}
