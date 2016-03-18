using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using headman.Region;
using headman.Event;
using System.Xml.Serialization;
using System.Windows.Shapes;

namespace headman.СurrentMoment
{
    [Serializable]
    public class CurrentMoment
    {
        public string MapName { get; set; }
        public int GameMonth { get; set; }
        public DateTime SaveDate { get; set; }

        public int Population { get; set; }
        public int Water { get; set; }
        public int Wood { get; set; }
        public int Stone { get; set; }

        public int CurrentRegionIndex { get; set; }
        public List<Path> Islands { get; set; }
        public List<Region.Region> Regions {get; set;}
        public List<IEvent> GoodEvents { get; set; }
        public List<IEvent> BadEvents { get; set; }
        public bool[] Items { get; set; }


    }
}
