using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadarATC
{
   
    public partial class RadarATC : Form
    {
        public RadarATC()
        {
            InitializeComponent();
        }

        #region variables
        //These are the start and end positions for the only runway
        Position runwayA_A = new Position(250, 150); 
        Position runwayA_B = new Position(250, 400);
        Position ATC = new Position(250, 250);
        //These are the positions for the exit/enter points
        Position exitEnterA = new Position(250, 50);
        Position exitEnterB = new Position(250, 450);

        // This is the list of all aircraft currently in the system
        List<Aircraft> AllAircraft = new List<Aircraft>();

        //This is the runway queue containing all aircraft which have been granted cleareannce to depart and waiting for an opening on the runway
        Queue<Aircraft> runwayQueue = new Queue<Aircraft>();
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             * Form1_Load is called once the page is initially loaded. It's currently only being used to create a timer which is currently set to tick
             * every second. Every time the timer ticks, timer_Tick is called, which contains most of the code for updating the system.
             */
            Timer timer = new Timer();
            timer.Interval = (1000);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        #region function for every second
        private void timer_Tick(object sender, EventArgs e)
        {
            /*
             * timer_Tick is called every time the timer created in Form1_Load ticks. Currently that is set to 1 second, so this function is called
             * every second to update the locations of the aircraft based on their speed and heading, check if they have been granted clearance to
             * depart, and call the function that updates and redraws the map graphic so that it shows the most current location of the aircraft
             */

            List<Aircraft> eraselist = new List<Aircraft>();
            foreach (Aircraft currentAircraft in listBox1.Items)
            {

                currentAircraft.position.posX += currentAircraft.speed * 0.03f * (float)Math.Sin(currentAircraft.heading * Math.PI / 180);
                currentAircraft.position.posY -= currentAircraft.speed * 0.03f * (float)Math.Cos(currentAircraft.heading * Math.PI / 180);

                //This moves airplanes on the screen based on their speed and heading

                if (currentAircraft.clearanceToDepart == true)
                {
                    /*
                     * This checks to see if the current aircraft has been granted clearance to depart from the user. If so, this checks whether the aircraft is
                     * at the front of the runway queue. If the aircraft is at the front of the runway queue, this adjusts the aircraft's position to show it
                     * departing. Once the aircraft has departed and is no longer on screen, this removes the aircraft from the runway queuue and ListBox1 (which 
                     * shows all departing aircraft.)          
 */
                    if (runwayQueue.Peek() == currentAircraft)
                    {
                        if (currentAircraft.nearestEntry == exitEnterA)
                        {
                            currentAircraft.heading = 0;
                        }
                        else
                        {
                            currentAircraft.heading = 180;
                        }
                        if (currentAircraft.speed <= 200)
                        {
                            currentAircraft.speed += 30;
                        }
                        if (currentAircraft.altitude <= 9000)
                        {
                            currentAircraft.altitude += 500;
                        }
                    }
                    if (currentAircraft.position.posX < (0 - (Properties.Resources.flight2.Height)) || currentAircraft.position.posY < 0 || currentAircraft.position.posX > 500 || currentAircraft.position.posY > 500)
                    {
                        eraselist.Add(currentAircraft);
                        currentAircraft.clearanceToDepart = false;
                        runwayQueue.Dequeue();
                        listBox3.Items.Remove(currentAircraft);
                    }
                }
            }

            foreach (Aircraft currentAircraft in listBox2.Items)
            {
                currentAircraft.position.posX += currentAircraft.speed * 0.03f * (float)Math.Sin(currentAircraft.heading * Math.PI / 180);
                currentAircraft.position.posY -= currentAircraft.speed * 0.03f * (float)Math.Cos(currentAircraft.heading * Math.PI / 180);
                if (Math.Pow(currentAircraft.position.posX - (250 - Properties.Resources.flight2.Width / 2), 2) + Math.Pow(currentAircraft.position.posY - (250 - Properties.Resources.flight2.Height / 2), 2) <= 40500)
                {
                    // inside of the airspace
                    if (currentAircraft.control != ' ') 
                    {
                        // inside of the airspace but still not controlled by ATC

                        float estPosX = currentAircraft.position.posX + 50 * currentAircraft.speed * 0.03f * (float)Math.Sin(currentAircraft.heading * Math.PI / 180);
                        float estPosY = currentAircraft.position.posY - 50 * currentAircraft.speed * 0.03f * (float)Math.Cos(currentAircraft.heading * Math.PI / 180);
                        Position estimatePos = new Position(estPosX, estPosY);                        
                        
                        if (checkIntersect(runwayA_A, runwayA_B, estimatePos, currentAircraft.position) == true || (currentAircraft.position.posX < ATC.posX + 5 && currentAircraft.position.posX > ATC.posX - 5 && currentAircraft.heading == 0) && currentAircraft.clearanceToLanding == false)
                        {
                            /*check aircraft will be meet with runway soon (2 conditions)
                             *  1. intersection between estimated Path of air
                             *  If it will have intersection, tell the ATC to put in runwayQueue*/
                            if (runwayQueue.Count == 0)
                            {
                                runwayQueue.Enqueue(currentAircraft);
                                listBox3.Items.Add(currentAircraft);
                            }
                        }
                        else if (currentAircraft.position.posX < ATC.posX + 5 && currentAircraft.position.posX > ATC.posX - 5 && currentAircraft.position.posY < runwayA_B.posY && currentAircraft.position.posY > runwayA_A.posY - 20)
                        {
                            /*When aircraft is almost close to the runway, it has to check runwayQueue. If it is the top of runway queue, it can get a clearance for landing and prepare to land.*/
                            if (currentAircraft.clearanceToLanding == false)
                            {
                                if (runwayQueue.Count != 0 && runwayQueue.Peek() == currentAircraft)
                                {
                                    //give clearance to landing
                                    currentAircraft.clearanceToLanding = true;
                                    currentAircraft.heading = 0;
                                }
                            }
                            else
                            {
                                /*if the aircraft has clearance for landing, it can be 2 conditions.
                                 * 1. It is now landing.
                                 * 2. It has already landed.
                                 */
                                if (currentAircraft.speed == 0 && currentAircraft.altitude == 0)    //it has already landed
                                {
                                    runwayQueue.Dequeue();
                                    listBox3.Items.Remove(currentAircraft);
                                    eraselist.Add(currentAircraft);
                                    AllAircraft.Remove(currentAircraft);
                                }
                                else if (currentAircraft.speed <= 30)   //almost landed
                                {
                                    currentAircraft.speed = 0;
                                    currentAircraft.altitude = 0;
                                }
                                else  //it is now landing
                                {
                                    currentAircraft.speed = currentAircraft.speed - 10;
                                }
                            }
                        }
                    }
                }
                else
                {
                    //outside of the airspace
                    if (currentAircraft.position.posY >= exitEnterB.posY + 30 || currentAircraft.position.posY <= exitEnterA.posY - 30)
                    {
                        //The aircraft's heading has to be toward the entry
                        Position newpos = new Position(currentAircraft.nearestEntry.posX * 2 - currentAircraft.position.posX - Properties.Resources.flight2.Width / 2, currentAircraft.nearestEntry.posY * 2 - currentAircraft.position.posY);
                        currentAircraft.heading = getHeading(currentAircraft.heading, currentAircraft.position, newpos);
                    }
                    else if (currentAircraft.position.posX >= currentAircraft.nearestEntry.posX - 15 - Properties.Resources.flight2.Width / 2 && currentAircraft.position.posX <= currentAircraft.nearestEntry.posX + 15 + Properties.Resources.flight2.Width / 2)
                    {
                        //when aircraft is close to the entry, go inside into the airspace
                        if (currentAircraft.nearestEntry == exitEnterA)
                        {
                            currentAircraft.heading = 180;
                        }
                        else
                        {
                            currentAircraft.heading = 0;
                        }

                    }
                }
            }
            foreach (Aircraft aircraft in eraselist)
            {
                /*Remove the aircrafts that are already landed or departed*/
                if (listBox1.Items.Contains(aircraft))
                {
                    listBox1.Items.Remove(aircraft);
                }
                if (listBox2.Items.Contains(aircraft))
                {
                    listBox2.Items.Remove(aircraft);
                }
                AllAircraft.Remove(aircraft);
            }
            eraselist.Clear();
            pictureBox1.Refresh();
        }
        #endregion

        #region check intersection
        float CCW(Position A, Position B, Position C)
        {

            return (A.posX * B.posY + B.posX * C.posY + C.posX * A.posY) - (B.posX * A.posY + C.posX * B.posY + A.posX * C.posY);
        }

        bool checkIntersect(Position A1, Position A2, Position B1, Position B2)
        {
            if ((CCW(A1, A2, B1) * CCW(A1, A2, B2) <= 0) && (CCW(B1, B2, A1) * CCW(B1, B2, A2) <= 0))
            {
                return true;

            }
            else
            {
                return false;
            }

        }
        #endregion

        int getHeading(int nowheading,Position nowpos, Position destpos)
        {
            double deltaX = (destpos.posX - nowpos.posX);
            double deltaY = (destpos.posY - nowpos.posY);
            int heading;

            if(deltaX >= 0)
            {
                int angle = (int)(Math.Atan(deltaY / deltaX) * 180 / Math.PI);
                if (deltaY >= 0)
                {        
                    heading = 90 + angle;
                }
                else
                {
                    heading = 90 + angle;
                }
            }

            else
            {
                int angle = (int)(Math.Atan(deltaY / deltaX) * 180 / Math.PI);
                if (deltaY >= 0)
                {
                    heading = 270 + angle; 
                }
                else
                {
                    heading = 270 + angle;
                }
            }
            return heading;
        }

        #region Painting
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            /*
             * PictureBox1 contains the map and the aircraft. Every time this funciton is called, it refreshes the image
             * in PictureBox1 to match the current location of the aircraft.
             */
            Graphics g = e.Graphics;

            //These pens are all labeled based how thick the lines they draw are in pixels
            float[] dashValues1 = { 3, 1 };
            float[] dashValues2 = { 1 };
            Pen mydotPen2 = new Pen(Color.Green, 2);
            mydotPen2.DashPattern = dashValues2;

            Pen mydotPen4 = new Pen(Color.Red, 4);
            mydotPen4.DashPattern = dashValues1;

            Pen myPen8 = new Pen(Color.Red, 8);
            Pen myPen4 = new Pen(Color.Red, 4);
            Pen myPen2 = new Pen(Color.Red, 2);
            Pen myPen = new Pen(Color.Red, 1);


            //This draws the four lines needed to draw the runway

            //g.DrawLine(myPen4, runwayA_A.posX-2, runwayA_A.posY, runwayA_B.posX-2, runwayA_B.posY);
            //g.DrawLine(myPen4, runwayA_A.posX+2, runwayA_A.posY, runwayA_B.posX+2, runwayA_B.posY);
            g.DrawLine(mydotPen4, runwayA_A.posX-5, runwayA_A.posY, runwayA_B.posX-5, runwayA_B.posY);                               
            g.DrawLine(mydotPen4, runwayA_A.posX+5, runwayA_A.posY, runwayA_B.posX+5, runwayA_B.posY);

            //This draws the five circles representing the 10-mile markers
            g.DrawEllipse(myPen4, 50, 50, 400, 400);
            g.DrawEllipse(myPen, 90, 90, 320, 320);
            g.DrawEllipse(myPen, 130, 130, 240, 240);
            g.DrawEllipse(myPen, 170, 170, 160, 160);
            g.DrawEllipse(myPen, 210, 210, 80, 80);

            //This draws the exit/enter points into the airspace
            g.DrawRectangle(myPen8, exitEnterA.posX - 30, exitEnterA.posY - 1, 60, 2);
            g.DrawRectangle(myPen8, exitEnterB.posX - 30, exitEnterB.posY - 1, 60, 2);

            //This is the brushes and font used for drawing aircraft
            Font drawFont = new Font("Arial", 8);
            Brush drawBrush = new SolidBrush(Color.Red);

            //This draws each aircraft in AllAircraft and adds the corresponding text containing flight information
            Image flightIcon = Properties.Resources.flight2;
            
            foreach (Aircraft currentAircraft in AllAircraft)
            {
                checkCollision(currentAircraft);
                
                g.DrawImage(flightIcon, currentAircraft.position.posX, currentAircraft.position.posY);
                g.DrawString((currentAircraft.aircraftID + " " + currentAircraft.airportID + " " + currentAircraft.control), drawFont, drawBrush, new Point((int)currentAircraft.position.posX + 30, (int)currentAircraft.position.posY + 30));
                string altitude;
                if (currentAircraft.altitude < 10000)
                {
                    altitude = "0" + (int)currentAircraft.altitude * 0.01;
                }
                else
                {
                    altitude = "" + (int)currentAircraft.altitude * 0.01;
                }
                g.DrawString((altitude + " " + currentAircraft.speed + " " + currentAircraft.heading), drawFont, drawBrush, new Point((int)currentAircraft.position.posX + 30, (int)currentAircraft.position.posY + 40));
            }

            void checkCollision(Aircraft currentaircraft)
            {
                /*check the collision between each aircrafts*/

                List<Aircraft> warnlist = new List<Aircraft>();
                List<Aircraft> colllist = new List<Aircraft>();

                foreach (Aircraft compareaircraft in AllAircraft)
                {
                    if(currentaircraft != compareaircraft && compareaircraft.control != ' ')
                    {
                        if (Math.Pow(currentaircraft.position.posX - compareaircraft.position.posX, 2) + Math.Pow(currentaircraft.position.posY - compareaircraft.position.posY, 2) < 800) //it has to be 576 originally, but too small
                        {
                            if (Math.Abs(currentaircraft.altitude - compareaircraft.altitude) < 1000)
                            {
                                if (Math.Pow(currentaircraft.position.posX - compareaircraft.position.posX, 2) + Math.Pow(currentaircraft.position.posY - compareaircraft.position.posY, 2) < 550)
                                {
                                    /*Aircrafts already collide*/
                                    colllist.Add(compareaircraft);                                    
                                }
                                else
                                {
                                    /*Aircrafts are too close to each other that has to shown warning*/
                                    warnlist.Add(compareaircraft);
                                }
                            }
                        }
                    }

                }
                 
                foreach (Aircraft aircraft in colllist)
                {
                    g.DrawEllipse(myPen2, aircraft.position.posX, aircraft.position.posY, 20, 20);
                }

                foreach (Aircraft aircraft in warnlist)
                {
                    g.DrawEllipse(myPen, aircraft.position.posX, aircraft.position.posY, 20, 20);
                }

                warnlist.Clear();
                colllist.Clear();
            }
        }
        #endregion
       
        #region create Aircraft
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            /*
             * PictureBox1 contains the map and all the aircraft. Clicking PictureBox1 is what generates new aircraft.
             */

            if (Math.Pow((MousePosition.X - (RadarATC.ActiveForm.Left + pictureBox1.Location.X + 288)), 2) + Math.Pow((MousePosition.Y - (RadarATC.ActiveForm.Top + pictureBox1.Location.Y + 288)), 2) < 40000)
            {
                /* 
                 * This if statement is triggered if the mouse location is within the boundaries necessary to generate a departing
                 * aircraft, instead of an arriving aircraft. The following generates a departing aircraft, and adds it to the the list
                 * of all aircraft. It also adds it to listBox1, which contains all departing aircraft.
                 */
                Position currentExitPoint;

                if (randomExitPoint() == 1)
                {
                    currentExitPoint = exitEnterA;
                }
                else
                {
                    currentExitPoint = exitEnterB;
                }
                Position currentPosition = new Position(((runwayA_A.posX + runwayA_B.posX) / 2 + 10), ((runwayA_A.posY + runwayA_B.posY) / 2));
                AllAircraft.Add(new Aircraft(randomAircraftID(), randomAirportID(), ' ', 0, 0, 0, currentPosition, currentExitPoint));  //CHANGE D->SPACE
                listBox1.Items.Add(AllAircraft.Last());
            }
            else
            {
                /*arriving aircraft is created on the position that user clicked*/
                Position currentPosition = new Position(MousePosition.X - (RadarATC.ActiveForm.Left + pictureBox1.Location.X + Properties.Resources.flight2.Width / 2), MousePosition.Y - (RadarATC.ActiveForm.Top + pictureBox1.Location.Y + Properties.Resources.flight2.Height));
                AllAircraft.Add(createArriveAircraft(currentPosition));
                listBox2.Items.Add(AllAircraft.Last());
            }
        }

        Aircraft createArriveAircraft(Position currentPosition)
        {            
            Position currentExitPoint;
            int heading;

            if (currentPosition.posY <= 250)
            {
                currentExitPoint = exitEnterA;
                heading = 0;
            }
            else
            {
                currentExitPoint = exitEnterB;
                heading = 180;
            }
            return new Aircraft(randomAircraftID(), "GFK", ' ', 100, heading, 8000, currentPosition, currentExitPoint);
        }
        #endregion
        
        #region create randomID
        public int randomExitPoint()
        {
            /*
             * This is used while creating random departing aircraft. Since they generate in the center of the map, the departing aircraft
             * are not closer to either exit or entry point. This just returns an int, which is later used to determine an exit/enter point
             * for a departing aircraft to depart from
             */

            Random random = new Random();
            return random.Next(1, 3);

        }
        
        public string randomAircraftID()
        {
            /*
             * This generates a random aircraft ID (AA263, DT620, LT216, for example) and returns a string
             * with that ID.
             */

            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            int i;
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
            i = random.Next(0,9);
            builder.Append(i);
            i = random.Next(0,9);
            builder.Append(i);
            i = random.Next(0,9);
            builder.Append(i);
            return builder.ToString();
        }

        public string randomAirportID()
        {
            /*
             * This generates a random three character airport ID (MSP, ELO, NJH for example) and returns a string
             * with that ID.
             */

            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
            return builder.ToString();
        }
        
        #endregion

        #region Listbox select function

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * ListBox1 has the departing aircraft in it. Once an aircraft is selected from ListBox1, a message box
             * appears and asks the user to give departure clearance to the selected aircraft. If the user clicks "no",
             * nothing happens. If the user clicks "yes", the flight is given clearance to depart, and added to the 
             * runway queue.
             */

            Aircraft selectedAircraft = (Aircraft)listBox1.SelectedItem;
            DialogResult result = DialogResult.No;
            if (selectedAircraft != null)
            {
                result = MessageBox.Show("Give Flight " + selectedAircraft.aircraftID + " on route to " + selectedAircraft.airportID + " clearance to depart?", "Departure Clearance", MessageBoxButtons.YesNo);
            }
            
            if (result == DialogResult.Yes)
            {
                if (selectedAircraft.clearanceToDepart == false)
                {
                    selectedAircraft.control = 'D'; 
                    selectedAircraft.clearanceToDepart = true;
                    selectedAircraft.position.posX = runwayA_A.posX - (Properties.Resources.flight2).Width / 2;
                    runwayQueue.Enqueue(selectedAircraft);
                    listBox3.Items.Add(selectedAircraft);
                }
            }
        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Aircraft selectedAircraft = (Aircraft)listBox2.SelectedItem;
            DialogResult result = DialogResult.No;
            if (selectedAircraft != null)
            {
                if (selectedAircraft.control == ' ')
                {   //starts to control
                    if (Math.Pow(selectedAircraft.position.posX - (250 - Properties.Resources.flight2.Width / 2), 2) + Math.Pow(selectedAircraft.position.posY - (250 - Properties.Resources.flight2.Height / 2), 2) <= 40500)
                    {
                        selectedAircraft.control = 'A';
                        result = MessageBox.Show("Flight " + selectedAircraft.aircraftID + " is now on the control of ATC");
                    }
                    else
                    {
                        result = MessageBox.Show("Flight " + selectedAircraft.aircraftID + "is outside of the airspace. ATC can't control");
                    }
                }
                else
                {
                    //change the control
                    int test;
                    if (Int32.TryParse(textBox_altitude.Text, out test) && Int32.TryParse(textBox_heading.Text, out test) && Int32.TryParse(textBox_speed.Text, out test))
                    {
                        selectedAircraft.speed = Convert.ToInt32(textBox_speed.Text);
                        selectedAircraft.heading = Convert.ToInt32(textBox_heading.Text);
                        selectedAircraft.altitude = Convert.ToInt32(textBox_altitude.Text);
                    }
                    else
                    {
                        result = MessageBox.Show("Write th altitude, speed and heading");
                    }
                    textBox_speed.Clear();
                    textBox_altitude.Clear();
                    textBox_heading.Clear();
                }
            }            
        }
        #endregion
    }
}
