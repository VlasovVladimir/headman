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
    class _54_letter : IEvent
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
            if (Moment.Population >= 2)
                Moment.Population -= 2;
            else
                Moment.Population = 0;

            result = "Вы прочитали письмо. Его автором оказался Луиджи. Человек с необычайно сильной злобной энергетикой и раскидистыми усами. Эти усы погубили двоих ваших товарищей. А письмо можно будет и дома дочитать.";
            Log += "Проклятие Луиджи погубило 2х ваших товарищей.";
        }

        public void Exit_2()
        {
            Moment.Population += 1;

            result = "Как водится, на нет и суда нет. Играем дальше.";
            Log += "И ничего не изменилось.";
        }

        public void Exit_3()
        {
            Moment.Items[0] = false;

            result = "Ваша медлительность заставила письмо самооткрыться. Про громовещатель слышали? А тут внутри было проклятье. Лишь флаг от вашей лодки остался в живых и полощется в водах океана.";
            Log += "Проклятье письма уничтожило лодку.";
        }

        public _54_letter()
        {
            Name = "Письмо";
            Description = "Вы обнаружили письмо. Как Вы с ним поступите?";
            Log = "Пришло письмо. ";

            Exit1 = "Прочитать";
            Exit2 = "Выбросить";
            Exit3 = "Эээ?..";
        }
    }
}

