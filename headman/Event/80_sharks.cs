using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using headman.Event;
using headman.СurrentMoment;
using headman.Forms.EventMenu;
using System.Xml.Serialization;

namespace headman.Event
{
    [Serializable]
    class _80_sharks : IRegionEvent
    {
        public CurrentMoment Moment { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Log { get; set; }

        public _80_sharks()
        {
            Name = "Нападение акул";
            int buf = Moment.Population;

            if (Moment.Population >= 7)
                Moment.Population -= 7;
            else
                Moment.Population = 0;

            buf = buf - Moment.Population;
            Description = "Пока вы переплывали с острова на остров, Вам повстречалась стая акул. Вы мужественно старались сражаться, однако, понесли потери. Ваша лодка пошла ко дну, и " + buf + " человек вместе с ней.";
            Log = "Нападение. Потеря лодки и " + buf + " товарищей.";
        }
    }
}
