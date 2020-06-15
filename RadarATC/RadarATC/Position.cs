using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarATC
{
    class Position
    {
        public float posX { get; set; }
        public float posY { get; set; }

        public Position(float X, float Y)
        {
            posX = X;
            posY = Y;
        }

        public override string ToString()
        {
            return "(" + posX + ", " + posY + ")";
        }
    }
}
