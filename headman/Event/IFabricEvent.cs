using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace headman.Event
{
     public interface IFabricEvent
    {
         List<IEvent> GoodEvents();
         List<IEvent> BadEvents();
    }
}
