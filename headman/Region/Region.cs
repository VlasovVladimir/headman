using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace headman.Region
{
    public class Region 
    {
        string Name;
        int Wood;
        int Stone;
        int Water;
        bool IsAvailabled;

        public Region(string name, int stone, int wood, int water)
        {
            Name = name;
            Wood = wood;
            Stone = stone;
            Water = water;
            IsAvailabled = false;
        }
        
    }
}

