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
    class _07_predators : IEvent
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
            if (Moment.Items[1])
            {
                if (Moment.Population >= 1)
                    Moment.Population -= 1;
                else
                    Moment.Population = 0;

                result = "А вы неплохо подготовились! Оборона с использованием топоров дала свои блистательные результаты. В ваших редах лишь одна потеря.";
                Log += "Вы потеряли 1 товарища.";
            }
            else
            {
                if (Moment.Population >= 10)
                    Moment.Population -= 10;
                else
                    Moment.Population = 0;

                int buf = Moment.Water;
            
                if (Moment.Water >= 5)
                    Moment.Water -= 5;
                else
                    Moment.Water = 0;

                buf = buf - Moment.Water;
                if (buf != 0)
                {
                    result = "Звери беспощадны. 10 ваших бойцов убито. " + buf + "ед. воды потеряно.";
                    Log += "10 человек погибло. " + buf + "ед. воды потеряно";
                }
                else
                {
                    result = "Звери беспощадны. 10 ваших бойцов убито.";
                    Log += "10 человек погибло.";
                }
            }
        }

        public void Exit_2()
        {
            result = "Удивительно, но факт. Вы настолько плохо поете, что звери сбежали, поджав хвост.";
            Log += "Без потерь.";
        }

        public void Exit_3()
        {
            if (Moment.Population >= 12)
                Moment.Population -= 12;
            else
                Moment.Population = 0;

            int buf = Moment.Water;
            if (Moment.Water >= 8)
                Moment.Water -= 8;
            else
                Moment.Water = 0;

            buf = buf - Moment.Water;
            if (buf != 0)
            {
                result = "Попытаться приручить хищных зверей? Удивительно, что вы вообще еще живы. Они выпили всю предложенную им воду и закусили вашими товарищами.";
                Log += "Вы потеряли 12 человек и " + buf + "ед. воды.";
            }
            else
            {
                result = "Звери беспощадны. 12 ваших бойцов убито.";
                Log += "12 человек погибло.";
            } 
        }

        public _07_predators()
        {
            Name = "Нападение хищных зверей";
            Description = "Под грозное рычание, под злостное мычание, под страшное бурчание рождаются во свет! Ужасные рептилии, коварные бастилии и злобный корвадот!";
            Log = "Нападение хищников. ";

            Exit1 = "На все воля Властителей!";
            Exit2 = "За-пе-вай!";
            Exit3 = "Ко мне, кис-кис.";
        }
    }
}