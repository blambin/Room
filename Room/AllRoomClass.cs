using System;
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
        bool Hot
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



    class OutsideWithDoor : Outside,IHasExteriorDoor
    {
        
    }

    class RoomWithDoor : Room,IHasExteriorDoor
    {
        
    }
}
