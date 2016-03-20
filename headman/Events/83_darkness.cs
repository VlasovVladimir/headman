using headman.СurrentMoment;
using System.Xml.Serialization;


namespace headman.Event
{
    class _83_darkness : IRegionEvent
    {

        [XmlIgnore]
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


