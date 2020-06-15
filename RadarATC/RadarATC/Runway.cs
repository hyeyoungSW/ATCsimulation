using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarATC
{
    class Runway
    {
        public Position[] runwayVector = new Position[2];

        public Runway(Position posX, Position posY)
        {
            runwayVector[0] = posX;
            runwayVector[1] = posY;
        }


    }
}
