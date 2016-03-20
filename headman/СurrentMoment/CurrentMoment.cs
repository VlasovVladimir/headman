using System;
using System.Collections.Generic;

namespace headman.СurrentMoment
{
    [Serializable]
    public class CurrentMoment
    {
        public string MapName { get; set; }
        public int GameMonth { get; set; }
        public int LastMonthOfMoving { get; set; }
        public DateTime SaveDate { get; set; }

        public int Population { get; set; }
        public int Water { get; set; }
        public int Wood { get; set; }
        public int Stone { get; set; }

        public int CurrentRegionIndex { get; set; }
        
        public List<Region.Region> Regions {get; set;}
        public List<int> GoodEvents { get; set; }
        public List<int> BadEvents { get; set; }
        public bool[] Items { get; set; }

        public CurrentMoment() { }

    }
}
