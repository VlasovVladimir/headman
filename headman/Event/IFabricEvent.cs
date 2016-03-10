using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace headman.Event
{
     public interface IFabricEvent
    {
         public List<IEvent> GoodEvents();
         public List<IEvent> BadEvents();
    }
}
