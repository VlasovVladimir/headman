using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using headman.Event;
using headman.СurrentMoment;
using System.Windows;
using headman.Forms.EventMenu;
using System.Xml.Serialization;

namespace headman.Event
{
    [Serializable]
    class _03_bark_beetles : IEvent
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
            int buf = Moment.Wood;

            if (Moment.Wood >= 8)
                Moment.Wood -= 8;
            else
                Moment.Wood = 0;

            buf = buf - Moment.Wood;
            if (buf != 0)
            {
                result = "Вы потеряли " + buf + "ед. дерева.";
                Log += result;
            }
            else
            {
                result = "";
                Log += "";
            }
        }

        public void Exit_2()
        {
            Moment.Items[4] = false;
            Moment.Wood = 0;
            result = "Бесполезно пытаться идти против Властителей. Вы сожгли зараженное дерево, но огонь перекинулся на выши жилища. Вы лишились и крыши над головой, и всех деревянных ресурсов.";
            Log += "Вы потеряли все дерево и дом.";
        }

        public void Exit_3()
        {
            if (Moment.Water >= 2)
            {
                int bufW = Moment.Wood;
                Moment.Water -= 2;

                if (Moment.Wood >= 3)
                    Moment.Wood -= 3;
                else
                    Moment.Wood = 0;

                bufW = bufW - Moment.Wood;
                if (bufW != 0)
                {
                    result = "Вам удалось победить вредителей. Потеряны лишь " + bufW + "ед. дерева";
                    Log += "Вы потеряли " + bufW + "ед. дерева";
                }
                else
                {
                    result = "";
                    Log += "";
                }
            }
            else
            {
                MessageBox.Show("К сожалению, имеющихся у вас запасов воды недостаточно для организации полноценного потопа.");
                Exit_1();
            }
        }

        public _03_bark_beetles()
        {
            Name = "Жуки-короеды";
            Description = "Под радостное жужжание в вашу жизнь входит грусть и разрушение. Жуки-короеды! Просим любить и не жаловаться.";
            Log = "Жуки-короеды. ";

            Exit1 = "На все воля Властителей!";
            Exit2 = "Сожжем зараженное дерево!";
            Exit3 = "Утопим коварных вредителей!";
        }
    }
}
