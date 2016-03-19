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
            
                if(Moment.Items[0])
                    Moment.Items[0]= false;
                else
                {
                    if (Moment.Wood != 0)
                        Moment.Wood = 0;
                }
                result = "Уот так уот";
                    Log += "";
            
        }

        public void Exit_2()
        {
            Exit_1();
        }

        public void Exit_3()
        {
            Exit_1();
        }

        public _18_damn_boat()
        {
            Name = "Проклятая лодка";
            if (Moment.Items[0])
            {
                Description = "Во время строительства своей лодки вы использовали дерево, что было проклято две сотни лет назад. Это проклятье настигло вас - лодка испарилась.";
                Log = "Ваша лодка оказалось проклятой и исчезла.";
            }
            else
            {
                if (Moment.Wood != 0)
                {
                    Description = "А если точнее - материалы для лодки. Так вышло, что все собранное вами дерево испарилось. Вдруг. Совсем.";
                    Log = "Ваше дерево исчезло.";
                }
                else
                {
                    Description = "Или не проклятая. Или не лодка. Странно все в этом мире.";
                    Log = "Что-то странное.";
                }
            }
            Exit1 = "Такова жизнь.";
            Exit2 = "Ce est la vie";
            Exit3 = "אַזאַ איז לעבן";
        }
    }
}