using headman.СurrentMoment;

namespace headman.Event
{
    class _11_thieves : IEvent
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
            if (Moment.Items[0])
            {
                Moment.Items[0] = false;
                result = "Грабители забрали вашу лодку";
                Log += "Вы лишились лодки";
            }
            else
            {
                Moment.Population -= 1;
                result = "Грабители вас заметили и успели захватить одного из ваших товарищей, а затем убежали";
                Log += "Вы лишились 1 товарища";
            }
        }

        public void Exit_2()
        {
            if (Moment.Items[0])
            {
                Moment.Items[0] = false;
                result = "Грабители сбежали, но захватили с собой вашу лодку";
                Log += "Вы лишились лодки";
            }
            else
            {
                Moment.Population -= 1;
                result = "Грабители сбежали, однако, один из аборигенов успел кинуть отравленный дротик и вы лишились 1 товарища";
                Log += "Вы лишились 1 товарища";
            }
        }

        public void Exit_3()
        {
            if (Moment.Items[0])
            {
                Moment.Items[0] = false;
                result = "Пока вы медлили, грабители обошли территорию лагеря и забрали самое ценной - лодку.";
                Log += "Вы лишились лодки";
            }
            else
            {
                Moment.Population -= 1;
                result = "Грабители спокойно осмотрели территорию и, не найдя ничего, ушли, однако, один из аборигенов успел кинуть отравленный дротик и вы лишились 1 товарища";
                Log += "Вы лишились 1 товарища";
            }
        }

        public _11_thieves()
        {
            Name = "Грабители";
            Description = "По возвращению в лагерь, вы увидели грабителей.";
            Log = "Грабители. ";

            Exit1 = "Спрятаться под сень леса";
            Exit2 = "Вон отсюда!";
            Exit3 = "Какие грабители?";
        }
    }
}
