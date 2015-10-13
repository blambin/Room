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
        public Form1()
        {
            InitializeComponent();
        }

        

        public void CreateObjects()
        {
            
        }

        private void MoveTOANewLocation(Location location)
        {
            Location currentLocation;
            currentLocation = location;
            comboBoxExits.Items.Clear();
            comboBoxExits.Items.Add(currentLocation.Exits);
            comboBoxExits.SelectedIndex = 0;

            textBox1.Text = currentLocation.Description;

            if (currentLocation is IHasExteriorDoor)
                buttonGoThoughTheDoor.Visible = true;
            buttonGoThoughTheDoor.Visible = false;



        }

        private void buttonGoHere_Click(object sender, EventArgs e)
        {
            MoveTOANewLocation(comboBoxExits.SelectedIndex);
        }

        private void buttonGoThoughTheDoor_Click(object sender, EventArgs e)
        {

        }
    }
}
