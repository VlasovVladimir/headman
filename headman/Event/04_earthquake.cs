using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using headman.Event;
using headman.СurrentMoment;
using headman.Forms.EventMenu;
using System.Windows;

namespace headman.Event
{
    class _04_earthquake : IEvent
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

            result = "Землетрясение разрушило ваши дома";
            Log += result;
            Description desk = new Description(result, null);
            desk.Show();
        }

        public void Exit_2()
        {
            if (Moment.Items[4])
            {
                Moment.Items[4] = false;

                if (Moment.Population >= 3)
                    Moment.Population -= 3;
                else
                    Moment.Population = 0;

                result = "Не самое разумное решение - бежать под своды зданий во время землетрясения. Ваши дома разрушены. Трое товарищей погребены под их стенами.";
                Log += "Вы потеряли дома и 3 товарищей.";
                Description desk = new Description(result, null);
                desk.Show();
            }
            else
            {
                MessageBox.Show("Упс. У вас нет домов.");
                Exit_1();
            }
        }

        public void Exit_3()
        {
            if (Moment.Items[0])
            {
                if (Moment.Population >= 1)
                    Moment.Population -= 1;
                else
                    Moment.Population = 0;

                result = "Вы приняли верное решение. Однако, один ваш товарищ погиб. Такова жизнь.";
                Log += "Вы потеряли 1 товарища.";
                Description desk = new Description(result, null);
                desk.Show();
            }
            else
            {
                MessageBox.Show("Упс. У вас нет лодки.");
                Exit_1();
            }
        }

        public _04_earthquake()
        {
            Name = "Землетрясение";
            Description = "Мир содрогается, скалы рушатся - страшное землетрясение постигло вашу обитель.";
            Log = "Землетрясение. ";

            Exit1 = "На все воля Властителей! Бла-бла-бладушки. курнуть. выпить. кря!";
            Exit2 = "Спрячемся в дома!";
            Exit3 = "На лодку и в океан.";
        }
    }
}
