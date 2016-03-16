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
    class _83_darkness : IRegionEvent
    {
        public CurrentMoment Moment { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Log { get; set; }

        public void action()
        {
            if (Moment.Population >= 5)
                Moment.Population -= 5;
            else
                Moment.Population = 0;
            Description = "При входе на остров вас накрыла черная тень. Когда она отступила, вы увидели, что пятеро ваших товарищей безвозвратно исчезли.";
            Log = "Черная тень. Потеря 5 товарищей.";
        }

        public _83_darkness()
        {
            Name = "Черная тень.";
        }
    }
}


