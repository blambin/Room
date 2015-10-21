using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Room
{
    public partial class Form1 : Form
    {
        int Moves;

        Location currentLocation;
        Room diningRoom;
        RoomWithDoor kitchen;
        RoomWithDoor livingRoom;
        Room stairs;

        RoomWithHidingPlace hallway;
        RoomWithHidingPlace bathroom;
        RoomWithHidingPlace masterBedroom;
        RoomWithHidingPlace secondBedroom;

        
        OutsideWithDoor frontYard;
        OutsideWithDoor backYard;
        OutsideWithHiding garden;
        OutsideWithHiding driverway;

        Opponent opponent;


        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            MoveTOANewLocation(livingRoom);
            textBox1.Multiline = true ;

            opponent = new Opponent(frontYard);
            ResetGame(false);


        }

        

        public void CreateObjects()
        {


            livingRoom = new RoomWithDoor("Living Room", "古董毛毯", "铜把手的橡树门","inside the closet");
            diningRoom = new Room("Dining Room","水晶吊灯");
            kitchen = new RoomWithDoor("Kitchen", "不锈钢家具","纱门","in the cabinet");
            stairs = new Room("Stairs", "a wooden bannister.");

            hallway = new RoomWithHidingPlace("Upstairs Hallway", "a picture of a dog", "in the closet");
            bathroom = new RoomWithHidingPlace("Bathroom","a sink and a toilet","in the shower");
            masterBedroom = new RoomWithHidingPlace("Master Bedroom","a larfe bed","under the bed");
            secondBedroom = new RoomWithHidingPlace("second Bedroom","a small bed","under the bed");


            frontYard = new OutsideWithDoor("Front Yard", true, "铜把手的橡树门");
            backYard = new OutsideWithDoor("Back Yard", false, "纱门");
            garden = new  OutsideWithHiding("Garden", false,"inside the shed");
            driverway = new OutsideWithHiding("Driver Way", true, "in the garage");


            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            livingRoom.Exits = new Location[] { diningRoom,stairs };
            kitchen.Exits = new Location[] { diningRoom };
            stairs.Exits = new Location[] { livingRoom,hallway};
            hallway.Exits = new Location[] { stairs, bathroom, masterBedroom, secondBedroom };
            bathroom.Exits = new Location[] { hallway};
            masterBedroom.Exits = new Location[] { hallway};
            secondBedroom.Exits = new Location[]{hallway};


            frontYard.Exits = new Location[] { backYard, garden };
            backYard.Exits = new Location[] { frontYard, garden };
            garden.Exits = new Location[] { backYard, frontYard };
            driverway.Exits = new Location[] { backYard, frontYard };


            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;

            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;


        }

        private void MoveTOANewLocation(Location newLocation)
        {
            
            currentLocation = newLocation;
            Moves++;
            ReDrawForm();

            



        }

        private void ReDrawForm()
        {
            comboBoxExits.Items.Clear();

            for (int i = 0; i < currentLocation.Exits.Length; i++)
            {
                comboBoxExits.Items.Add(currentLocation.Exits[i].Name);
            }
            comboBoxExits.SelectedIndex = 0;

            textBox1.Text = currentLocation.Description + "\r\n(move #" + Moves +")";

            if (currentLocation is IHidingPlace)
            {
                IHidingPlace hidingPlace = currentLocation as IHidingPlace;
                buttonCheck.Text = "Check " + hidingPlace.HidingPlaceName;
                buttonCheck.Visible = true;
            }
            else
                buttonCheck.Visible = false;
            

            if (currentLocation is IHasExteriorDoor)
                 buttonGoThoughTheDoor.Visible = true;
            else
                    buttonGoThoughTheDoor.Visible = false;
            
            
        }

        private void ResetGame(bool displayMessage)
        {
          if (displayMessage)
          {
            MessageBox.Show("You found me in " + Moves + " moves!");
            IHidingPlace foundLocation = currentLocation as IHidingPlace;
            textBox1.Text = "You found your opponent in " + Moves + " moves! He was hiding " + foundLocation.HidingPlaceName + ".";    
          }
            Moves = 0;
            buttonHide.Visible = true;
            buttonGoHere.Visible = false;
            buttonGoThoughTheDoor.Visible = false;
            buttonCheck.Visible = false;
            comboBoxExits.Visible = false;

        }


        private void buttonGoHere_Click(object sender, EventArgs e)
        {
            MoveTOANewLocation(currentLocation.Exits[comboBoxExits.SelectedIndex]);
        }

        private void buttonGoThoughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveTOANewLocation(hasDoor.DoorLocation);
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            Moves++;
            if (opponent.Check(currentLocation))
                ResetGame(true);
            else
                ReDrawForm();
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            buttonHide.Visible = false;
            for (int i = 0; i < 10; i++)
            {
                opponent.Move();
                textBox1.Text = "init " + i + " .... ";
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
            }

            textBox1.Text = "Ready or not ,here we come!";
            Application.DoEvents();
            System.Threading.Thread.Sleep(1200);

            buttonGoHere.Visible = true;
            buttonGoThoughTheDoor.Visible = true;
            comboBoxExits.Visible = true;
            MoveTOANewLocation(livingRoom);
        }
    }
}
