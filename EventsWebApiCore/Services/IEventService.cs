using EventsWebApiCore.Models;

namespace EventsWebApiCore.Services
{
    public interface IEventService
    {
        public Task<IEnumerable<Event>> GetEvents(int page, int pageSize);
        public Task<EventUserViewModel> GetEventInfo(int id);
        public Task<Event> CreateEvent(Event eventItem);
        public Task<Event> UpdateEventDetails(Event updatedEvent);
        public bool DeleteEvent(int Id);
    }
}
