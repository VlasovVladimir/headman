using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using headman.Event;
using headman.СurrentMoment;
using headman.Forms.EventMenu;
using System.Xml.Serialization;

namespace headman.Event
{
    [Serializable]
    class _81_aborigens : IRegionEvent
    {
        [XmlIgnore]
        public CurrentMoment Moment { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Log { get; set; }

        public void action()
        {
            if (Moment.Items[5])
            {
                Moment.Stone += 5;
                Moment.Water += 5;
                Moment.Wood += 5;
                int buf = Moment.Population;

                if (Moment.Population >= 3)
                    Moment.Population -= 3;
                else
                    Moment.Population = 0;

                buf = buf - Moment.Population;
                Description = "Гостеприимный остров встретил вас ватагой не очень дружелюбно настроенных аборигенов. Благодаря тому, что вы были вооружены копьями, потери оказались минимальны: " + buf + " товарища. Также, вам, как победившей стороне, досталось по 5ед. ресурсов";
                Log = "Нападение аборигенов. Потеря " + buf + " товарищей. Приобретение по 5ед. всех ресурсов";
            }
            else
            {
                int buf = Moment.Population;

                if (Moment.Population >= 10)
                    Moment.Population -= 10;
                else
                    Moment.Population = 0;

                buf = buf - Moment.Population;
                Moment.Water = 0;
                Description = "Гостеприимный остров встретил вас ватагой не очень дружелюбно настроенных аборигенов. Вы потеряли " + buf + " товарищей. Также, у вас забрали всю воду";
                Log = "Нападение аборигенов. Потеря " + buf + " товарищей. Потеря всех водных ресурсов.";
            }
        }

        public _81_aborigens()
        {
            Name = "Злобные местные жители";
        }
    }
}

