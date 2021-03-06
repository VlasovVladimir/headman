﻿using headman.СurrentMoment;

namespace headman.Event
{
    public class _94_hack : IEvent
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
            if (!Moment.Items[3])
            {
                Moment.Items[3] = true;
                result = "Боги даровали вам кирки";
                Log += result;
            }
            else
            {
                result = "Боги даровали вам кирки, но они у вас есть. Очень жаль!";
                Log += result;
            }
        }

        public void Exit_2()
        {
            Exit_1();
        }

        public void Exit_3()
        {
            Exit_1();
        }

        public _94_hack()
        {
            Name = "Вы нашли кирки";
            Description = "Вы гуляли по острову и нашли кирки!";
            Log = "";

            Exit1 = "Спасибо большое! ^_^";
            Exit2 = "Thank you!";
            Exit3 = "Kiitos!";
        }
    }
}
