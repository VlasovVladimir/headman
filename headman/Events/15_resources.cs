using headman.СurrentMoment;

namespace headman.Event
{
    class _15_resources : IEvent
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
            Moment.Stone += 20;

            result = "Число Ваших камней увеличилось на 20.";
            Log += "Вы получили 20ед. камней.";
        }

        public void Exit_2()
        {
            Moment.Wood += 20;

            result = "Число Вашего дерева увеличилось на 20.";
            Log += "Вы получили 20ед. дерева.";
        }

        public void Exit_3()
        {
            Moment.Water += 20;

            result = "Число Вашей воды увеличилось на 20.";
            Log += "Вы получили 20ед. воды.";
        }

        public _15_resources()
        {
            Name = "Ресурсы";
            Description = "У ваших Властителей сегодня хороший день, а потому Вы можете выбрать, какой вид ресурсов Вам сейчас жизненно необходим.";
            Log = "Нежданное счастье. ";

            Exit1 = "Камни";
            Exit2 = "Дерево";
            Exit3 = "Вода";
        }
    }
}
