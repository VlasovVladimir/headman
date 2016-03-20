using headman.СurrentMoment;
using System.Xml.Serialization;

namespace headman.Event
{
    class _82_Matan : IRegionEvent
    {

        [XmlIgnore]
        public CurrentMoment Moment { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Log { get; set; }

        public void action()
        {
            bool flag = true;
            for (int i = 0; i < Moment.Items.Length; i++)
            {
                if (i != 4)
                    flag = flag & Moment.Items[i];
            }
            

            if (flag)
            {
                Moment.Stone += 5;
                Moment.Water += 5;
                Moment.Wood += 5;
                
                Description = "На острове с ухом вы встретили великого привередливого ученого. Он увидел, что вы были достаточно талантливы, чтобы собрать все предметы и даровал за это по 5ед. каждого ресурса.";
                Log = "Встреча с ученым. Увеличение числа всех ресурсов на 5";
            }
            else
            {


                if (Moment.Water >= 2)
                {
                    Moment.Water -= 2;
                    Moment.Population += 1;
                    Description = "На острове с ухом вы встретили великого привередливого ученого. Он увидел, что вы были недостаточно талантливы, чтобы собрать все предметы. Он принял решение помогать вам и присоединился к вашей команде. Чтобы побороть страшную жажду, он выпил 2ед. воды.";
                    Log = "Встреча с ученым. Увеличение команды на 1, потеря 2ед. воды.";
                }
                else
                {
                    Description = "На острове с ухом вы встретили великого привередливого ученого. Он увидел, что вы были недостаточно талантливы, чтобы собрать все предметы. Поняв, что взять с вас нечего, ученый ушел";
                    Log = "Встреча с ученым. Никаких изменений.";
                }                
            }
        }

        public _82_Matan()
        {
            Name = "Великий математик.";
        }
    }
}

