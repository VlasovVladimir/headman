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
    class _14_visitors : IEvent
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
            Moment.Population += 15;
            Moment.Items[5] = true;

            result = "Вы попытались прогнать гостей, а они проявили свое уважение и признали ваше превосходство. Теперь в вашей команде 15 новых членов. И копья в придачу.";
            Log += "Вы приобрели 15 товарищей и набор копий.";
        }            

        public void Exit_2()
        {
            Moment.Population += 15;

            result = "Аборигены присоединились к вам. Теперь в вашей команде 15 новых членов.";
            Log += "Вы приобрели 15 товарищей.";
        }

        public void Exit_3()
        {
            result = "Аборигены удивились вашей аморфности и предпочли уйти от такого безэмоционального предводителя.";
            Log += "Ушли ни с чем.";
        }

        public _14_visitors()
        {
            Name = "Нежданные гости";
            Description = "На границе вашего лагеря появились коренные жители острова. На самом ли деле они мирные, или только притворяются?";
            Log = "Визитеры. ";

            Exit1 = "Прочь!";
            Exit2 = "Проходите! Хлеб да Соль.";
            Exit3 = "Пусть будут";
        }
    }
}
