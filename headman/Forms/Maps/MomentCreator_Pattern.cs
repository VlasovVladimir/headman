using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using headman.СurrentMoment;
using headman.Event;

namespace headman.Forms.Maps
{
    public class MomentCreator_Pattern
    {
        public MomentCreator_Pattern() { }

        public CurrentMoment Create()
        {
            CurrentMoment output = new CurrentMoment();

            EventIndexes indexs = new EventIndexes();   // тут поменять при добавлении новой карты
            output.BadEvents = indexs.BadEventsIndexes();
            output.GoodEvents = indexs.GoodEventsIndexes();
            output.LastMonthOfMoving = -10;
            output.CurrentRegionIndex = 0;
            output.Population = 100;
            output.Regions = null; //тут тоже
            output.Stone = 0;
            output.Wood = 0;
            output.Water = 5;
            output.GameMonth = 1;
            output.Items = new bool[6];
            for (int i = 0; i < output.Items.Length; i++)
            {
                output.Items[i] = false;
            }

            return output;

        }
    }
}