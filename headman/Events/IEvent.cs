using headman.СurrentMoment;

namespace headman.Event
{
    public interface IEvent
    {
        CurrentMoment Moment { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Log{get;set;}
        string result { get; set; }

        string Exit1 { get; set; }
        string Exit2 { get; set; }
        string Exit3 { get; set; }

        void Exit_1();
        void Exit_2();
        void Exit_3();
    }
}
