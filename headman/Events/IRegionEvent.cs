using headman.СurrentMoment;

namespace headman.Event
{
    public interface IRegionEvent
    {
        CurrentMoment Moment { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Log { get; set; }

        void action();
    }
}
