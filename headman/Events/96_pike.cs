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
            if (!Moment.Items[5])
            {
                Moment.Items[5] = true;
                result = "Боги даровали вам копья";
                Log += result;
            }
            else
            {
                result = "Боги даровали вам копья, но они у вас есть. Очень жаль!";
                Log += result;
            }
        }

        public void Exit_2()
        {
            Exit_1();
        }

        public void Exit_3()
        {
            Exit_1();
        }

        public _96_pike()
        {
            Name = "Вы нашли копья";
            Description = "Вы гуляли по острову и нашли копья!";
            Log = "";

            Exit1 = "Спасибо большое! ^_^";
            Exit2 = "Thank you!";
            Exit3 = "감사합니다!";
        }
    }
}
