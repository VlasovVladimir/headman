using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using headman.СurrentMoment;

namespace headman.Event
{
    public interface IRegionEvent
    {
        CurrentMoment Moment { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Log { get; set; }

        void action();
    }
}
