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
        Location currentLocation;
        Room diningRoom;
        RoomWithDoor kitchen;
        RoomWithDoor livingRoom;

        Outside garden;
        OutsideWithDoor frontYard;
        OutsideWithDoor backYard;


        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            MoveTOANewLocation(livingRoom);
            textBox1.Multiline = true ;
        }

        

        public void CreateObjects()
        {
            livingRoom = new RoomWithDoor("Living Room", "古董毛毯", "铜把手的橡树门");
            diningRoom = new Room("Dining Room","水晶吊灯");
            kitchen = new RoomWithDoor("Kitchen", "不锈钢家具","纱门");

            frontYard = new OutsideWithDoor("Front Yard", true, "铜把手的橡树门");
            backYard = new OutsideWithDoor("Back Yard", false, "纱门");
            garden = new Outside("Garden", false);

            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            livingRoom.Exits = new Location[] { diningRoom };
            kitchen.Exits = new Location[] { diningRoom };

            frontYard.Exits = new Location[] { backYard, garden };
            backYard.Exits = new Location[] { frontYard, garden };
            garden.Exits = new Location[] { backYard, frontYard };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;

            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;


        }

        private void MoveTOANewLocation(Location newLocation)
        {
            
            currentLocation = newLocation;
            comboBoxExits.Items.Clear();

            for (int i = 0; i < currentLocation.Exits.Length; i++)
            {
                comboBoxExits.Items.Add(currentLocation.Exits[i].Name);
            }
            comboBoxExits.SelectedIndex = 0;

            textBox1.Text = currentLocation.Description;

            if (currentLocation is IHasExteriorDoor)
                buttonGoThoughTheDoor.Visible = true;
            else
                buttonGoThoughTheDoor.Visible = false;



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
    }
}
