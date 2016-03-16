using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace headman.Region
{
    public class Region 
    {
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
        }
        
    }
}

