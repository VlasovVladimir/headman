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

            output.Add(new TestGoodEvent());

            return output;
        }

        public List<IEvent> BadEvents()
        {
            List<IEvent> output = new List<IEvent>();
            
            output.Add(new _01_plague());
            output.Add(new _02_drought());
            output.Add(new _03_bark_beetles());
            output.Add(new _04_earthquake());

            return output;
        }
    }
}
