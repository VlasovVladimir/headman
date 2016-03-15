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
    class _06_eruption : IEvent
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

            if (Moment.Population >= 5)
                Moment.Population -= 5;
            else
                Moment.Population = 0;

            Moment.Stone = Moment.Stone / 2;
            Moment.Water = Moment.Water / 2;
            Moment.Wood = Moment.Wood / 2;

            result = "Вы достойно приняли неизбежное. Ваши дома разрушены. Погибло 5 отважных героев, которым удалось спасти половину ваших ресурсов.";
            Log += "Дома разрушены. 5 человек погибло. Половина ресурсов уничтожена.";
            Description desk = new Description(result, null);
            desk.Show();
        }

        public void Exit_2()
        {
            Exit_1();
        }

        public void Exit_3()
        {
            Exit_1();
        }

        public _06_eruption()
        {
            Name = "Извержение вулкана";
            Description = "Помните Помпеи? Тут, кажется, может быть хуже.";
            Log = "Извержение вулкана. ";

            Exit1 = "Ок.";
            Exit2 = "Ок :)";
            Exit3 = "Ок :(";
        }
    }
}