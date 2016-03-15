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
    class _09_fireball : IEvent
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
            Moment.Items[4] = false;
            Moment.Items[0] = false;

            result = "Ваша попытка провести ритуал в пользу Властителей с сжиганием лодки не принесла результатов. Ваш дом разрушен. Зато все живы!";
            Log += "Вы потеряли лодку и дома.";
            Description desk = new Description(result, null);
            desk.Show();
        }

        public void Exit_2()
        {
            Moment.Items[4] = false;
            result = "Молния разрушила ваши дома. Зато никого из людей не задело, ведь все смотрели на огонечки!";
            Log += "Вы потеряли дома.";
            Description desk = new Description(result, null);
            desk.Show();
        }

        public void Exit_3()
        {
            if (Moment.Population >= 5)
                Moment.Population -= 5;
            else
                Moment.Population = 0;

            Moment.Items[4] = false;

            result = "Доисследовались? Дом разрушен, 5 главных исследователей погибло. Не дорожите вы своими людьми.";
            Log += "Вы потеряли 5х товарищей и крышу над головой.";
            Description desk = new Description(result, null);
            desk.Show();
        }

        public _09_fireball()
        {
            Name = "Шаровая молния";
            Description = "С радостным -Взюююх!- в небесах появляется светящийся шар. Молния. Как думаете, как лучше с ней общаться?";
            Log = "Шаровая молния. ";

            Exit1 = "На все воля Властителей!";
            Exit2 = "Ууууу, огонё-ё-ёчки!";
            Exit3 = "Необходимо исследовать.";
        }
    }
}

