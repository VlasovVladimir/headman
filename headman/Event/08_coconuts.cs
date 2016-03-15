﻿using System;
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
    class _08_coconuts : IEvent
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
            if (Moment.Population >= 1)
                Moment.Population -= 1;
            else
                Moment.Population = 0;

            result = "Кокос убил одного вашего товарища.";
            Log += "Вы потеряли 1 товарища.";
            Description desk = new Description(result, null);
            desk.Show();
        }

        public void Exit_2()
        {
            if (Moment.Population >= 2)
                Moment.Population -= 2;
            else
                Moment.Population = 0;

            result = "Кокос убил 2х ваших товарищей.";
            Log += "Вы потеряли 2 товарищей.";
            Description desk = new Description(result, null);
            desk.Show();
        }

        public void Exit_3()
        {
            if (Moment.Population >= 3)
                Moment.Population -= 3;
            else
                Moment.Population = 0;

            result = "Кокос убил трех ваших товарищей.";
            Log += "Вы потеряли 3х товарищей.";
            Description desk = new Description(result, null);
            desk.Show();
        }

        public _08_coconuts()
        {
            Name = "Кокосы";
            Description = "Осторожно, возможны осадки в виде твердых тяжелых предметов. Слышали? Бегите, глупцы, вас атакуют кокосы.";
            Log = "Падение кокосов. ";

            Exit1 = "Уууу";
            Exit2 = "Оооо";
            Exit3 = "Аааа";
        }
    }
}
   