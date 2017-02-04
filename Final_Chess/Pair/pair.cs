using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final_Chess
{
    public class pair
    {
        private int x;
        private int y;
        public pair(int y, int x)
        {
            this.x = x;
            this.y = y;
        }
        public int x_property
        {
            get { return x; }
            set { x = value; }
        }
        public int y_property
        {
            get { return y; }
            set { y = value; }
        }
    }
}
