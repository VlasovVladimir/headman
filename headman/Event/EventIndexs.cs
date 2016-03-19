using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace headman.Event
{
    public class EventIndexs
    {
        public List<int> GoodEventsIndexs()
        {
            return new List<int> { 91, 92, 93, 94, 95, 96, 13, 14, 15, 16, 17, 70, 51, 52, 53 };
        }
        
        public List<int> BadEventsIndexs()
        {
            return new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 22, 54, 11, 12 };
        }
    }
}
