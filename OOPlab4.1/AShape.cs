using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPlab4._1
{
    abstract class AShape
    {
        public abstract void Draw();
        public abstract AShape Clone();
    }
}
