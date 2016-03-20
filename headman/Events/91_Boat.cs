using headman.СurrentMoment;

namespace headman.Event
{
    public class _91_Boat : IEvent
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
            if (!Moment.Items[0])
            {
                Moment.Items[0] = true;
                result = "Боги даровали вам лодку";
                Log += result;
            }
            else
            {
                result = "Боги даровали вам лодку, но она у вас есть. Очень жаль!";
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

        public _91_Boat()
        {
            Name = "Вы нашли лодку";
            Description = "Вы гуляли по острову и нашли лодку!";
            Log = "";

            Exit1 = "Спасибо большое! ^_^";
            Exit2 = "Thank you!";
            Exit3 = "תודה";
        }
    }
}
