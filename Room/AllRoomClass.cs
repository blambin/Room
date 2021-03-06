﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room
{
    abstract class Location
    {
        public Location(string name)
        {
            this.name = name;
        }

        public Location[] Exits;
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public virtual string Description
        {
            get
            {
                string description = "You're standing in the " + name + ". You see exits to the following places: ";
                for (int i = 0; i < Exits.Length; i++)
                {
                    description += " " + Exits[i].Name;
                    if (i != Exits.Length - 1)
                        description += ",";
                }
                description += ".";
                return description;
            }
        }

    }

    class Room:Location
    {
        private string decoration;
        public string Decoration
        {
            get { return decoration; }
        }
        public Room(string name,string decoration):base(name)
        {
            this.decoration = decoration;
        }


        public override string Description
        {
            get
            {
                return base.Description + " You see " + decoration + " here.";
            }
        }
    }
    class Outside:Location
    {
        private bool hot;
        public bool Hot
        {
            get { return hot; }
        }
        public Outside(string name, bool hot):base(name)
        {
            this.hot = hot;
        }
        public override string Description
        {
            get
            {
                if (hot == true)
                    return base.Description + " It's very hot here.";
                return base.Description;
            }
        }
    }



    class OutsideWithDoor : Outside ,IHasExteriorDoor
    {
        public OutsideWithDoor(string name, bool hot, string doorDescription)
            : base(name, hot)
        {
            this.doorDescription = doorDescription;
        }

        private string doorDescription;
        public string DoorDescription
        {
            get { return doorDescription; }
        }

        private Location doorLocation;
        public Location DoorLocation
        {
            get { return doorLocation; }
            set { doorLocation = value; }
        }

        public override string Description
        {
            get
            {
                return base.Description + " You see " + doorDescription + ".";
            }
        }
    }

    class RoomWithDoor : RoomWithHidingPlace ,IHasExteriorDoor
    {

        public RoomWithDoor(string name, string decoration, string doordescription, string hidingPlaceName)
            : base(name, decoration, hidingPlaceName)
        {
            this.doordescription = doordescription;
        }

        private string doordescription;
        public string DoorDescription
        {
            get { return doordescription; }
        }

        private Location doorLocation;
        public Location DoorLocation
        {
            get { return doorLocation; }
            set { doorLocation = value; }
        }
    }

    class RoomWithHidingPlace : Room, IHidingPlace
    {
        public RoomWithHidingPlace(string name,string decoration,string hidingPlaceName):base(name,decoration)
        {
            this.hidingPlaceName = hidingPlaceName;
        }

        private string hidingPlaceName;
        public string HidingPlaceName
        {
            get { return hidingPlaceName; }
        }

        public override string Description
        {
            get
            {
                return base.Description + " Someone could hide " + hidingPlaceName + ".";
            }
        }

    }

    class OutsideWithHiding : Outside,IHidingPlace
    {
        public OutsideWithHiding(string name,bool hot,string hidingPlaceName):base(name,hot)
        {
            this.hidingPlaceName = hidingPlaceName;
        }
        private string hidingPlaceName;
        public string HidingPlaceName
        {
            get { return hidingPlaceName; }
        }
        public override string Description
        {
            get
            {
                return base.Description + " Someone could hide " + hidingPlaceName + ".";
            }
        }
    }

    class Opponent
    {
        private Location myLocation;
        private Random random;

        public Opponent(Location startLocation)
        {
            this.myLocation = startLocation;
            random = new Random();
  
        }

        public void Move()
        {
            if (myLocation is IHasExteriorDoor)
            {
                IHasExteriorDoor LocationWithDoor = myLocation as IHasExteriorDoor;
                if (random.Next(2)==1)
                {
                    myLocation = LocationWithDoor.DoorLocation;
                }
            }

            bool hiden = false;
            while (!hiden)
            {
                int rand = random.Next(myLocation.Exits.Length);
                myLocation = myLocation.Exits[rand];
                if (myLocation is IHidingPlace)
                    hiden = true;
            }
                
        }

        public bool Check(Location location)
        {
            if (this.myLocation == location)
                return true;
            else
                return false;
        }


    }


}
