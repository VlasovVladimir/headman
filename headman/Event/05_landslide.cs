using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using headman.Event;
using headman.СurrentMoment;
using headman.Forms.EventMenu;
using System.Windows;
using System.Xml.Serialization;

namespace headman.Event
{
    [Serializable]
    class _05_landslide : IEvent
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
            Moment.Items[4] = false;
            if (Moment.Population >= 2)
                Moment.Population -= 2;
            else
                Moment.Population = 0;

            result = "Обвал разрушил ваши дома и загубил двоих товарищей.";
            Log += "Вы потеряли дома и 2 товарищей.";
        }

        public void Exit_2()
        {
            if (Moment.Items[4])
            {
                if (Moment.Water >= 1)
                    Moment.Water -= 1;
                else
                    Moment.Water = 0;

                result = "Ополозень прошел стороной от вашего дома. Ушло чуть больше воды, чем обычно.";
                Log += "Вы потеряли 1ед. воды.";
            }
            else
            {
                MessageBox.Show("Упс. У вас нет домов.");
                Exit_1();
            }
        }

        public void Exit_3()
        {
            Moment.Items[4] = false;

            if (Moment.Population >= 2)
                Moment.Population -= 2;
            else
                Moment.Population = 0;

            Moment.Stone += 2;
            
            result = "Ваши дома разрушены. Двое товарищей своим криком призвали камни на себя и погибли. Зато, благодаря им, у вас прибавилось 2ед. камня.";
            Log += "Вы потеряли дома и 2 товарищей. Число камней увеличилось на 2.";
        }

        public _05_landslide()
        {
            Name = "Горный обвал";
            Description = "Мир содрогается, скалы рушатся - горный обвал набирает силу, снося все на своем пути.";
            Log = "Горный обвал. ";

            Exit1 = "На все воля Властителей!";
            Exit2 = "Спрячемся в дома!";
            Exit3 = "Паника!";
        }
    }
}