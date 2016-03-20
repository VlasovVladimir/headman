using headman.СurrentMoment;

namespace headman.Event
{
    class _17_resources : IEvent
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
            Moment.Stone += 15;

            result = "Число Ваших камней увеличилось на 15.";
            Log += "Вы получили 15ед. камней.";
        }

        public void Exit_2()
        {
            Moment.Wood += 15;

            result = "Число Вашего дерева увеличилось на 15.";
            Log += "Вы получили 15ед. дерева.";
        }

        public void Exit_3()
        {
            Moment.Water += 15;

            result = "Число Вашей воды увеличилось на 15.";
            Log += "Вы получили 15ед. воды.";
        }

        public _17_resources()
        {
            Name = "Ресурсы";
            Description = "Пришло время делать выбор.";
            Log = "Нежданное счастье. ";

            Exit1 = "Камни";
            Exit2 = "Дерево";
            Exit3 = "Вода";
        }
    }
}
