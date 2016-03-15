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
            if (Moment.Water >= 8)
                Moment.Water -= 8;
            else
                Moment.Water = 0;
             
            result = "Вы потеряли 8ед. дерева.";
            Log += result;
            Description desk = new Description(result, null);
            desk.Show();
        }

        public void Exit_2()
        {
            Moment.Items[4] = false;
            Moment.Wood = 0;
            result = "Бесполезно пытаться идти против Властителей. Вы сожгли зараженное дерево, но огонь перекинулся на выши жилища. Вы лишились и крыши над головой, и всех деревянных ресурсов.";
            Log += "Вы потеряли все дерево и дом.";
            Description desk = new Description(result, null);
            desk.Show();
        }

        public void Exit_3()
        {
            if (Moment.Water >= 2)
            {
                Moment.Water -= 2;

                if (Moment.Wood >= 3)
                    Moment.Wood -= 3;
                else
                    Moment.Wood = 0;

                result = "Вам удалось победить вредителей. Потеряны лишь 3ед. дерева";
                Log += "Вы потеряли 3ед. дерева";
                Description desk = new Description(result, null);
                desk.Show();
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
