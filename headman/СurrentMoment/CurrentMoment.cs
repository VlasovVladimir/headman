﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using headman.Region;
using headman.Event;
using System.Xml.Serialization;

namespace headman.СurrentMoment
{
    [Serializable]
    public class CurrentMoment
    {
        public int GameMonth { get; set; }
        public DateTime SaveDate { get; set; }

        public int Population { get; set; }
        public int Water { get; set; }
        public int Wood { get; set; }
        public int Stone { get; set; }

        public List<IRegion> Regions {get; set;}
        public List<IEvent> GoodEvents { get; set; }
        public List<IEvent> BadEvents { get; set; }


    }
}
