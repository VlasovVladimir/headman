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
    class _51_music : IEvent
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
            if (Moment.Population >= 5)
                Moment.Population -= 5;
            else
                Moment.Population = 0;

            result = "Рэп сказался на психическом сознание ваших товарищей. Оказалось несколько настолько слабых духом, что, пропитавшись прослушанной музыкой, они ушли в леса. Их было пятеро.";
            Log += "Вы решили послушать рэп и потеряли 5 товарищей.";
            Description desk = new Description(result, null);
            desk.Show();
        }

        public void Exit_2()
        {
            Moment.Population += 1;

            result = "Звуки шансона привлекли в ваши ряды одного аборигена, несмотря на то, что он немного тюремного вида, это дополнительные рабочие руки!";
            Log += "Шансон помог вам увеличить ваши ряды на 1 человека.";
            Description desk = new Description(result, null);
            desk.Show();
        }

        public void Exit_3()
        {
            if (Moment.Population >= 5)
                Moment.Population -= 5;
            else
                Moment.Population = 0;

            result = "Колыбельная же усыпляет, не очевидно было, да? А спящие люди подвержены нападениям. В общем, ваши ряды поредели. На пятерых.";
            Log += "Колыбельная убила 5 ваших товарищей.";
            Description desk = new Description(result, null);
            desk.Show();
        }

        public _51_music()
        {
            Name = "Музыкальная пауза ♫";
            Description = "Время послушать музыку. Выбирай.";
            Log = "Музыкальная пауза. ";

            Exit1 = "Русский рэп";
            Exit2 = "Шансон";
            Exit3 = "Колыбельная";
        }
    }
}

