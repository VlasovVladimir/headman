using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using headman.СurrentMoment;
using headman.Event;

namespace headman.Forms.Maps
{
    public class StartCurrentPatternMomentCreator
    {
        public StartCurrentPatternMomentCreator() { }

        public CurrentMoment Create()
        {
            CurrentMoment output = new CurrentMoment();

            IFabricEvent eFabric = new FabricOfAllEvents();   // тут поменять при добавлении новой карты
            output.BadEvents = eFabric.BadEvents();
            output.GoodEvents = eFabric.GoodEvents();

            output.Population = 100;
            output.Regions = null; //тут тоже
            output.Stone = 0;
            output.Wood = 0;
            output.Water = 5;
            output.GameMonth = 1;


            return output;

        }
    }
}