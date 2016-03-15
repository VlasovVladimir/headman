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
    class _52_treasures : IEvent
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
            if (Moment.Population >= 3)
                Moment.Population -= 3;
            else
                Moment.Population = 0;

            result = "Аборигены считают деньги презренным металлом. Они настолько обезумели, что убили троих ваших товарищей.";
            Log += "3 ваших товарищей поплатились за них жизнью.";
        }

        public void Exit_2()
        {
            Moment.Wood += 1;

            result = "Аборигены приняли ваше пожертвование и отплатили вам 2ед. дерева.";
            Log += "Торг завершился успешно и увеличи ваши запасы дерева на 2.";
        }

        public void Exit_3()
        {
            Moment.Wood += 10;
            Moment.Items[4]= true;

            result = "Вы сделали верный выбор! Аборигены считают все, что сделано из дерева и имеет крышку, священным! В благодарность за подаренный сундук они отстроили вам дома и подарили 10ед. дерева.";
            Log += "Успешный торг принес вам10ед.дерева и отстроенные дома.";
        }

        public _52_treasures()
        {
            Name = "Сокровища";
            Description = "Вы нашли сундук сокровищ. Однако, вдруг появились аборигены и потребовали отдать что-либо в уплату за него. Что вы им предложите?";
            Log = "Сокровища. ";

            Exit1 = "Деньги";
            Exit2 = "Украшения";
            Exit3 = "Сундук";
        }
    }
}

