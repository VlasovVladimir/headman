﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using headman.Event;

namespace headman.Region
{
    public class Region 
    {
        public IRegionEvent Event;
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

        public Region(string name, int stone, int wood, int water, IRegionEvent someEvent)
        {
            Name = name;
            Wood = wood;
            Stone = stone;
            Water = water;
            Event = someEvent;
        }
        
    }
}

