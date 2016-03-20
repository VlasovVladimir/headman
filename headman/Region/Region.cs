using System;

namespace headman.Region
{
    [Serializable]
    public class Region 
    {
        
        public int Event;
        public string Name;
        public int Wood;
        public int Stone;
        public int Water;

        public Region(string name, int stone, int wood, int water)
        {
            Name = name;
            Wood = wood;
            Stone = stone;
            Water = water;
            Event = 0;
        }

        public Region(string name, int stone, int wood, int water, int someEvent)
        {
            Name = name;
            Wood = wood;
            Stone = stone;
            Water = water;
            Event = someEvent;
        }
        public Region() { }
        
    }
}

