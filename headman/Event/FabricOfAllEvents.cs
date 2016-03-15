using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace headman.Event
{
    public class FabricOfAllEvents: IFabricEvent
    {
        public List<IEvent> GoodEvents()
        {
            List<IEvent> output = new List<IEvent>();

            output.Add(new _91_Boat());
            output.Add(new _92_Axe());
            output.Add(new _93_flack());
            output.Add(new _94_hack());
            output.Add(new _95_house());
            output.Add(new _96_pike());
            output.Add(new _13_people());
            output.Add(new _14_visitors());
            output.Add(new _15_resources());
            output.Add(new _16_resources());
            output.Add(new _17_resources());
            output.Add(new _70_Bzzz());
            output.Add(new _51_music());
            output.Add(new _52_treasures());
            output.Add(new _53_why());

            return output;
        }

        public List<IEvent> BadEvents()
        {
            List<IEvent> output = new List<IEvent>();
            
            output.Add(new _01_plague());
            output.Add(new _02_drought());
            output.Add(new _03_bark_beetles());
            output.Add(new _04_earthquake());
            output.Add(new _05_landslide());
            output.Add(new _06_eruption());
            output.Add(new _07_predators());
            output.Add(new _08_coconuts());
            output.Add(new _09_fireball());
            output.Add(new _10_cannibals());
            output.Add(new _22_meneaters());
            output.Add(new _54_letter());
        
            return output;
        }
    }
}
