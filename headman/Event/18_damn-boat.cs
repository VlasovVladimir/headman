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
    class _18_damn_boat : IEvent
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
            if (Moment.Items[0])
            {
                Moment.Items[0] = false;
                result = "Разбойники забрали вашу лодку";
                Log += "Вы лишились лодки";
            }
            else
            {
                Moment.Population -= 1;
                result = "Разбойники вас заметили и успели захватить одного из ваших товарищей, а затем убежали";
                Log += "Вы лишились 1 товарища";
            }
        }

        public void Exit_2()
        {
            if (Moment.Items[0])
            {
                Moment.Items[0] = false;
                result = "Разбойники сбежали, но захватили с собой вашу лодку";
                Log += "Вы лишились лодки";
            }
            else
            {
                Moment.Population -= 1;
                result = "Разбойники сбежали, однако, один из аборигенов успел кинуть отравленный дротик и вы лишились 1 товарища";
                Log += "Вы лишились 1 товарища";
            }
        }

        public void Exit_3()
        {
            if (Moment.Items[0])
            {
                Moment.Items[0] = false;
                result = "Пока вы медлили, Разбойники обошли территорию лагеря и забрали самое ценной - лодку.";
                Log += "Вы лишились лодки";
            }
            else
            {
                Moment.Population -= 1;
                result = "Разбойники спокойно осмотрели территорию и, не найдя ничего, ушли, однако, один из аборигенов успел кинуть отравленный дротик и вы лишились 1 товарища";
                Log += "Вы лишились 1 товарища";
            }
        }

        public _18_damn_boat()
        {
            Name = "Проклятая лодка";
            if (Moment.Items[0])
            {
                Description = "Во время строительства своей лодки вы использовали дерево, что было проклято две сотни лет назад. Это проклятье настигло вас - лодка испарилась.";
                Log = "Ваша лодка оказалось проклятой и исчезла.";

                Exit1 = "Такова жизнь.";
                Exit2 = "Ce est la vie";
                Exit3 = "אַזאַ איז לעבן";
            }
            else
            {
                Description = "А если точнее - материалы для лодки. Так вышло, что все собранное вами дерево испарилось. Вдруг. Совсем.";
                Log = "Ваше дерево исчезло.";

                Exit1 = "Такова жизнь.";
                Exit2 = "Ce est la vie";
                Exit3 = "אַזאַ איז לעבן";
            }
        }
    }
}