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
    class _13_people : IEvent
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
            if (Moment.Items[2])
            {
                Moment.Items[2] = false;
                if (Moment.Water >= 5)
                    Moment.Water = 5;

                result = "Вы прогнали гостей. А они обозлились. И прихватили ваши фляги.";
                Log += "Вы потеряли фляги.";
                Description desk = new Description(result, null);
                desk.Show();
            }
            else
            {
                result = "Вы прогнали гостей. Ну, они и ушли. С вас и взять-то нечего.";
                Log += "Вы их выгнали.";
                Description desk = new Description(result, null);
                desk.Show();
            }
        }

        public void Exit_2()
        {

            result = "А вы удивительно не удачливый стратег. Аборигены оказались натуральными хлебофобами. Убежали, даже и тени не видать.";
            Log += "Сбежали.";
            Description desk = new Description(result, null);
            desk.Show();
        }

        public void Exit_3()
        {
           Moment.Population += 15;

            result = "Аборигены к вам присоединились. Теперь ваша команда больше на 15 человек.";
            Log += "Вы приобрели 15 товарищей.";
            Description desk = new Description(result, null);
            desk.Show();
        }

        public _13_people()
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
