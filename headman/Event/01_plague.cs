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
    public class _01_plague : IEvent
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
            if (Moment.Population >= 15)
                Moment.Population -= 15;
            else
                Moment.Population = 0;
            result = "Ваше бездействие повлекло гибель 15 товарищей.";
            Log += result;
            
        }

        public void Exit_2()
        {
            if (Moment.Population >= 20)
                Moment.Population -= 20;
            else
                Moment.Population = 0;
            
            result = "Изгнанники обозлились, вернулись и покусали часть племени. В конечном счете вы лишились 20 товарищей.";
            Log += "Брат пошел на брата. Погибло 20 человек.";
            
        }

        public void Exit_3()
        {
            if (Moment.Population >= 10)
                Moment.Population -= 10;
            else
                Moment.Population = 0;
            
            result = "Дым от молитвенных жезлов изгнал чуму из вашего племени. Ранее зараженных спасти не удалось. Погибло 10 человек.";
            Log += "Ваши молитвы спасли всех кроме 10 товарищей.";
           
        }

        public _01_plague()
        {
            Name = "Чума";
            Description = "Властители мира наслали на вас страшное проклятье: в племя пришла чума!";
            Log = "Чума. ";

            Exit1 = "На все воля Властителей!";
            Exit2 = "Изгнать прокаженных!";
            Exit3 = "Произнесем молитву, други.";
        }
    }
}
