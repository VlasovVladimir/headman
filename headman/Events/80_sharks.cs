﻿using headman.СurrentMoment;
using System.Xml.Serialization;

namespace headman.Event
{
    class _80_sharks : IRegionEvent
    {
        [XmlIgnore]
        public CurrentMoment Moment { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Log { get; set; }

        public void action()
        {

            int buf = Moment.Population;

            if (Moment.Population >= 7)
                Moment.Population -= 7;
            else
                Moment.Population = 0;

            buf = buf - Moment.Population;
            Description = "Пока вы переплывали с острова на остров, Вам повстречалась стая акул. Вы мужественно старались сражаться, однако, понесли потери. Ваша лодка пошла ко дну, и " + buf + " человек вместе с ней.";
            Log = "Нападение акул. Потеря лодки и " + buf + " товарищей.";
        }

        public _80_sharks()
        {
            Name = "Нападение акул";
        }
    }
}
