﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using headman.Event;
using headman.СurrentMoment;
using headman.Forms.EventMenu;

namespace headman.Event
{
    public class _96_pike: IEvent
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
            if (!Moment.Items[3])
            {
                Moment.Items[3] = true;
                result = "Боги даровали вам копья";
                Log += result;
            }
            else
            {
                result = "Боги даровали вам копья, но они у вас есть. Очень жаль!";
                Log += " Как жаль, что они у вас есть.";
            }
            Description desk = new Description(result, null);
            desk.Show();
        }

        public void Exit_2()
        {
            if (!Moment.Items[3])
            {
                Moment.Items[3] = true;
                result = "Боги даровали вам копья";
                Log += result;
            }
            else
            {
                result = "Боги даровали вам копья, но они у вас есть. Очень жаль!";
                Log += " Как жаль, что они у вас есть.";
            }
            Description desk = new Description(result, null);
            desk.Show();
        }

        public void Exit_3()
        {
            if (!Moment.Items[3])
            {
                Moment.Items[3] = true;
                result = "Боги даровали вам копья";
                Log += result;
            }
            else
            {
                result = "Боги даровали вам копья, но они у вас есть. Очень жаль!";
                Log += " Как жаль, что они у вас есть.";
            }
            Description desk = new Description(result, null);
            desk.Show();
        }

        public _96_pike()
        {
            Name = "Вы нашли копья";
            Description = "Вы гуляли по острову и нашли топоры!";
            Log = "";

            Exit1 = "Спасибо большое! ^_^";
            Exit2 = "Thank you!";
            Exit3 = "감사합니다!";
        }
    }
}
