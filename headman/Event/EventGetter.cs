using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace headman.Event
{
    public class EventGetter
    {
        public IEvent GetEventByIndex(int index)
        {
            IEvent curEvent = null;

            switch (index)
            {
                case (1):
                    {
                        curEvent = new _01_plague();
                        return curEvent;
                    }
                case (2):
                    {
                        curEvent = new _02_drought();
                        return curEvent;
                    }
                case (3):
                    {
                        curEvent = new _03_bark_beetles();
                        return curEvent;
                    }
                case (4):
                    {
                        curEvent = new _04_earthquake();
                        return curEvent;
                    }
                case (5):
                    {
                        curEvent = new _05_landslide();
                        return curEvent;
                    }
                case (6):
                    {
                        curEvent = new _06_eruption();
                        return curEvent;
                    }
                case (7):
                    {
                        curEvent = new _07_predators();
                        return curEvent;
                    }
                case (8):
                    {
                        curEvent = new _08_coconuts();
                        return curEvent;
                    }
                case (9):
                    {
                        curEvent = new _09_fireball();
                        return curEvent;
                    }
                case (10):
                    {
                        curEvent = new _10_cannibals();
                        return curEvent;
                    }
                case (11):
                    {
                        curEvent = new _11_thieves();
                        return curEvent;
                    }
                case (12):
                    {
                        curEvent = new _12_robbers();
                        return curEvent;
                    }
                case (13):
                    {
                        curEvent = new _13_people();
                        return curEvent;
                    }
                case (14):
                    {
                        curEvent = new _14_visitors();
                        return curEvent;
                    }
                case (15):
                    {
                        curEvent = new _15_resources();
                        return curEvent;
                    }
                case (16):
                    {
                        curEvent = new _16_resources();
                        return curEvent;
                    }
                case (17):
                    {
                        curEvent = new _17_resources();
                        return curEvent;
                    }
                case (18):
                    {
                        curEvent = new _18_damn_boat();
                        return curEvent;
                    }
                case (19):
                    {
                        curEvent = new _19_TestBadEvent();
                        return curEvent;
                    }
                case (20):
                    {
                        curEvent = new _20_TestGoodEvent();
                        return curEvent;
                    }
                case (22):
                    {
                        curEvent = new _22_meneaters();
                        return curEvent;
                    }
                case (51):
                    {
                        curEvent = new _51_music();
                        return curEvent;
                    }
                case (52):
                    {
                        curEvent = new _52_treasures();
                        return curEvent;
                    }
                case (53):
                    {
                        curEvent = new _53_why();
                        return curEvent;
                    }
                case (54):
                    {
                        curEvent = new _54_letter();
                        return curEvent;
                    }
                case (70):
                    {
                        curEvent = new _70_Bzzz();
                        return curEvent;
                    }
                case (91):
                    {
                        curEvent = new _91_Boat();
                        return curEvent;
                    }
                case (92):
                    {
                        curEvent = new _92_Axe();
                        return curEvent;
                    }
                case (93):
                    {
                        curEvent = new _93_flack();
                        return curEvent;
                    }
                case (94):
                    {
                        curEvent = new _94_hack();
                        return curEvent;
                    }
                case (95):
                    {
                        curEvent = new _95_house();
                        return curEvent;
                    }
                case (96):
                    {
                        curEvent = new _96_pike();
                        return curEvent;
                    }                    
            }


            return curEvent;
        }


        public IRegionEvent GetRegEventByIndex (int index)
        {
            IRegionEvent curEvent = null;

            switch (index)
            {
                case (80):
                    return new _80_sharks();

                case (81):
                    return new _81_aborigens();

                case (82):
                    return new _82_Matan();

                case (83):
                    return new _83_darkness();
            }

            return curEvent;
        }
    }
}
