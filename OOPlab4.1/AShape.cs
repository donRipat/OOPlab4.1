using System.Drawing;

namespace OOPlab4._1
{
    abstract class AShape
    {
        public abstract void Draw(Graphics g);
        public abstract AShape Clone();
        public abstract void Switch_current();
        public abstract void Switch_highlight();
        public abstract bool Contains(Point p);
    }
}
