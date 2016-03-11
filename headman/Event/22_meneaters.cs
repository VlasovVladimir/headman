using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using headman.Event;
using headman.СurrentMoment;
using headman.Forms.EventMenu;

namespace headman.Event
{
    class _22_meneaters : IEvent
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
            result = "Людоеды решили, что ваша покладистость скрывает страшную угрозу. И ушли. Вот так.";
            Log += "Пришли и ушли.";
            Description desk = new Description(result, null);
            desk.Show();
        }

        public void Exit_2()
        {
            if (!Moment.Items[5])
            {
                if (Moment.Population >= 10)
                    Moment.Population -= 10;
                else
                    Moment.Population = 0;
                result = "Сражаться здорово. Но без пик как-то глупо. Мало того, что пять человек погибло в бою, еще пятерых съели.";
                Log += "Вы потеряли 10 человек.";
                Description desk = new Description(result, null);
                desk.Show();
            }
            else
            {
                result = "Вы приняли верное решение! Людоеды повержены, ваши потери нулевые.";
                Log += "Без потерь.";
                Description desk = new Description(result, null);
                desk.Show();
            }
        }

        public void Exit_3()
        {
            if (Moment.Population >= 8)
                Moment.Population -= 8;
            else
                Moment.Population = 0;

            result = "Неразговорчивые вам попались ганнибалы. Огрызнулись и устроили широкую трапезу. Ваши ряды проредились. На 8 человек.";
            Log += "Вы потеряли 8 человек.";
            Description desk = new Description(result, null);
            desk.Show();
        }

        public _22_meneaters()
        {
            Name = "Людоеды";
            Description = "Ом-ном-ном. Вы питаетесь водой, а на этом острове есть люди, которым нужно больше энергии. И они достаточно агрессивно настроены. А вы?";
            Log = "Людоеды. ";

            Exit1 = "На все воля Властителей! Сдаемся.";
            Exit2 = "В атаку!";
            Exit3 = "Вы хотите поговорить об этом?";
        }
    }
}