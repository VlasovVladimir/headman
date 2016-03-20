using headman.СurrentMoment;

namespace headman.Event
{
    class _10_cannibals : IEvent
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

            result = "Сдались. Принесли пятерых в жертву. Людоеды ушли.";
            Log += "Вы потеряли 5х людей.";
        }

        public void Exit_2()
        {
            if (!Moment.Items[5])
            {
                if (Moment.Population >= 10)
                    Moment.Population -= 10;
                else
                    Moment.Population = 0;
                result = "Сражаться здорово. Но без пик как-то глупо. Мало того, что пять человек погибло в бою, еще пятерых съели.";
                Log += "Вы потеряли 10 человек.";
            }
            else
            {
                result = "Вы приняли верное решение! Людоеды повержены, ваши потери нулевые.";
                Log += "Без потерь.";
            }
        }

        public void Exit_3()
        {
            Moment.Population += 5;
            
            result = "Да у вас дар убеждения! В вашем полку прибыло.";
            Log += "Вы получили 5 человек в команду.";
        }

        public _10_cannibals()
        {
            Name = "Людоеды";
            Description = "Ом-ном-ном. Вы питаетесь водой, а на этом острове есть люди, которым нужно больше энергии. И они достаточно агрессивно настроены. А вы?";
            Log = "Людоеды. ";

            Exit1 = "На все воля Властителей! Сдаемся.";
            Exit2 = "В атаку!";
            Exit3 = "Вы хотите поговорить об этом?";
        }
    }
}

