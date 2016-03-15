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
    public class _02_drought : IEvent
    {
        public CurrentMoment Moment { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Log { get; set; }
        public string result { get; set; }

        public string Exit1 { get; set; }
        public string Exit2 { get; set; }
        public string Exit3 { get; set; }

        public void Exit_1()
        {
            if (Moment.Water >= 10)
                Moment.Water -= 10;
            else
                Moment.Water = 0;
            
            result = "Вы потеряли 10ед. воды.";
            Log += result;
        }

        public void Exit_2()
        {
            if (Moment.Water >= 12)
                Moment.Water -= 12;
            else
                Moment.Water = 0;

            if (Moment.Population >= 1)
                Moment.Population -= 1;
            else
                Moment.Population = 0;

            result = "Бесполезно пытаться идти против Властителей. Вы потеряли не только 12ед. воды, но 1 особенно рьяного копателя.";
            Log += "Вы потеряли 12 ед.воды и 1 товарища.";
        }

        public void Exit_3()
        {
            if (Moment.Water >= 10)
                Moment.Water -= 10;
            else
                Moment.Water = 0;

            result = "Ваши молитвы были услышаны, но не сразу. Вы потеряли 10ед.воды.";
            Log += result;
        }

        public _02_drought()
        {
            Name = "Засуха";
            Description = "Несчастье пришло в вашу жизнь. Страшная засуха накрыла злосчастный остров.";
            Log = "Засуха. ";

            Exit1 = "На все воля Властителей!";
            Exit2 = "Необходимо действовать! Колодец!";
            Exit3 = "Вознесем молитву, други.";
        }
    }
}

