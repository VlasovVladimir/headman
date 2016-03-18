using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using headman.Region;
using headman.СurrentMoment;
using headman.Event;

namespace headman.Forms.Maps.First
{
    class MomentCreator_First
    {

        public CurrentMoment Create()
        {

            CurrentMoment output = new CurrentMoment();

            IFabricEvent eFabric = new FabricOfAllEvents();   // тут поменять при добавлении новой карты
            output.BadEvents = eFabric.BadEvents();
            output.GoodEvents = eFabric.GoodEvents();

            //output.CurrentRegionIndex = 0;
            output.Population = 100;
            output.Regions = new List<headman.Region.Region>();
            output.Stone = 0;
            output.Wood = 0;
            output.Water = 5;
            output.GameMonth = 1;
            output.Items = new bool[6];
            for (int i = 0; i < output.Items.Length; i++)
            {
                output.Items[i] = false;
            }

            #region Region_making
            output.Regions.Add(new headman.Region.Region("Стартовый", 130, 130, 300));
            output.Regions.Add(new headman.Region.Region("Парящий", 95, 120, 200));
            output.Regions.Add(new headman.Region.Region("Малый", 80, 80, 150));
            output.Regions.Add(new headman.Region.Region("Гостеприимный", 102, 100, 250));
            output.Regions.Add(new headman.Region.Region("Отдельный", 78, 70, 150));
            output.Regions.Add(new headman.Region.Region("Призрачный", 138, 125, 200));
            output.Regions.Add(new headman.Region.Region("Каменистый", 170, 60, 175));
            output.Regions.Add(new headman.Region.Region("Тяф", 108, 95, 170));
            output.Regions.Add(new headman.Region.Region("Лесистый", 62, 170, 220));
            output.Regions.Add(new headman.Region.Region("Главный", 98, 115, 280));
            output.Regions.Add(new headman.Region.Region("Светлый", 88, 123, 190));
            output.Regions.Add(new headman.Region.Region("Скалистый", 140, 40, 140));
            output.Regions.Add(new headman.Region.Region("Пустынный", 35, 30, 80));
            output.Regions.Add(new headman.Region.Region("Двойной", 94, 90, 210));
            output.Regions.Add(new headman.Region.Region("Луговой", 12, 132, 200));
            output.Regions.Add(new headman.Region.Region("Незримый", 27, 102, 180));
            output.Regions.Add(new headman.Region.Region("Левый", 84, 94, 220));
            output.Regions.Add(new headman.Region.Region("Правый", 84, 94, 220));
            output.Regions.Add(new headman.Region.Region("Заветный", 187, 195, 500));

            #endregion
            return output;
        }
    }
}
