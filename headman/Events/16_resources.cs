using headman.СurrentMoment;

namespace headman.Event
{
    class _16_resources : IEvent
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
            Moment.Stone += 10;

            result = "Число Ваших камней увеличилось на 10.";
            Log += "Вы получили 10ед. камней.";
        }

        public void Exit_2()
        {
            Moment.Wood += 10;

            result = "Число Вашего дерева увеличилось на 10.";
            Log += "Вы получили 10ед. дерева.";
        }

        public void Exit_3()
        {
            Moment.Water += 10;

            result = "Число Вашей воды увеличилось на 10.";
            Log += "Вы получили 10ед. воды.";
        }

        public _16_resources()
        {
            Name = "Ресурсы";
            Description = "Хватайте, пока дают! Какие ресурсы Вам сейчас нужнее других?";
            Log = "Нежданное счастье. ";

            Exit1 = "Камни";
            Exit2 = "Дерево";
            Exit3 = "Вода";
        }
    }
}
