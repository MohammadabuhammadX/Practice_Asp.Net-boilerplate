using Abp.Events.Bus.Entities;

namespace Practice.Events
{
    public class EventDateChangedEvent : EntityEventData<Event>
    {
        public EventDateChangedEvent(Event entity) : base(entity)
        {

        }
    }
}
