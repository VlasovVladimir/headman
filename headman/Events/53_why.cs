using headman.СurrentMoment;
using System.Windows;

namespace headman.Event
{
    class _53_why : IEvent
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
            Log += "";

            MessageBox.Show("Удивительно, насколько Вы аморфны.");
        }

        public void Exit_2()
        {
            Log += "";

            MessageBox.Show("Вы подозрительно похожи на Сергея Леонидовича.");
        }

        public void Exit_3()
        {
            Log += "";

            MessageBox.Show("Вы подозрительно похожи на человека, который просит приготовить биф-ролл без сыра.");
        }

        public _53_why()
        {
            Name = "Время вопросов";
            Description = "Как вы думаете, почему?";
            Log = "Странный вопрос. ";

            Exit1 = "Прост)";
            Exit2 = "Жиза";
            Exit3 = "Потому что бесплатно";
        }
    }
}


