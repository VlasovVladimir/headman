﻿using System.Collections.Generic;

namespace headman.Event
{
    public class EventIndexes
    {
        public List<int> GoodEventsIndexes()
        {
            return new List<int> { 91, 92, 93, 94, 95, 96, 13, 14, 15, 16, 17, 70, 51, 52, 53, 20 };
        }
        
        public List<int> BadEventsIndexes()
        {
            return new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 22, 54, 11, 12, 18, 19 };
        }
    }
}
