﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using headman.Event;
using headman.СurrentMoment;
using headman.Forms.EventMenu;
using System.Windows;

namespace headman.Event
{
    class _70_Bzzz : IEvent
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
            Moment.Stone += 15;

            result = "☃ бзю-бзю, мой мальчик!";
            Log += "☃";
            MessageBox.Show(result);
        }

        public void Exit_2()
        {
            Exit_1();
        }

        public void Exit_3()
        {
            Exit_1();
        }

        public _70_Bzzz()
        {
            Name = "Бззззз!";
            Description = "Бзаааааа-бза!";
            Log = "Бз. ";

            Exit1 = "бза";
            Exit2 = "бза-бза-бза";
            Exit3 = "бзюк";
        }
    }
}
