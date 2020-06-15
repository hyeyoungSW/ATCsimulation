using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarATC
{
    class Aircraft
    {
        public String aircraftID { get; set; }
        public String airportID { get; set; }
        public Char control { get; set; }
        public float speed { get; set; }
        public int heading { get; set; }
        public int altitude { get; set; }
        public  Position position { get; set; }
        public Position nearestEntry { get; set; }
        public bool clearanceToDepart { get; set; }
        public bool clearanceToLanding { get; set; }

        public Aircraft(String AircraftID, String AirportID, Char Control, float Speed, int Heading, int Altitude, Position Position, Position NearestEntry)
        {
            aircraftID = AircraftID;
            airportID = AirportID;
            control = Control;
            speed = Speed;
            heading = Heading;
            altitude = Altitude;
            position = Position;
            nearestEntry = NearestEntry;
            clearanceToDepart = false;
            clearanceToLanding = false;
        }

    }
}
