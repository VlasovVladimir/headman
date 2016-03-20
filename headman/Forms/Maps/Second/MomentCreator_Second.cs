using System.Collections.Generic;
using headman.СurrentMoment;
using headman.Event;

namespace headman.Forms.Maps.Second
{
    class MomentCreator_Second
    {
        public CurrentMoment Create()
        {

            CurrentMoment output = new CurrentMoment();
            output.MapName = "Second";
            EventIndexes indexs = new EventIndexes(); // а ведь и тут менять..
            output.BadEvents = indexs.BadEventsIndexes();
            output.GoodEvents = indexs.GoodEventsIndexes();

            output.LastMonthOfMoving = -10;
            output.CurrentRegionIndex = 0;
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

            output.Regions.Add(new headman.Region.Region("Первый", 130, 130, 300));
            output.Regions.Add(new headman.Region.Region("Второй", 95, 120, 200));
            output.Regions.Add(new headman.Region.Region("Третий", 80, 80, 150));
            output.Regions.Add(new headman.Region.Region("Четвертый", 102, 100, 250));
            output.Regions.Add(new headman.Region.Region("Пятый", 78, 70, 150));

            #endregion
            return output;
        }
    }
}
