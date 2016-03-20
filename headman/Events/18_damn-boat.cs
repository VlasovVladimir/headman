using headman.СurrentMoment;

namespace headman.Event
{
    class _18_damn_boat : IEvent
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
                result = "Во время строительства своей лодки вы использовали дерево, что было проклято две сотни лет назад. Это проклятье настигло вас - лодка испарилась.";
                Log += "Ваша лодка оказалось проклятой и исчезла.";
            }
            else
            {
                if (Moment.Wood != 0)
                {
                    Moment.Wood = 0;
                    result = "Так вышло, что все собранное вами дерево испарилось. Вдруг. Совсем.";
                    Log += "Ваше дерево исчезло.";
                }
                else
                {
                    result = "Как-то туго у вас с достижениями. И взять-то нечего.";
                    Log += "Бездейственное.";

                }
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

        public _18_damn_boat()
        {
            Name = "Проклятие";
            Description = "На вас послано проклятие, действие которого зависит от ваших текущих успехов.";
            Log = "Проклятие. ";
            
            Exit1 = "Такова жизнь.";
            Exit2 = "Ce est la vie";
            Exit3 = "אַזאַ איז לעבן";
        }
    }
}