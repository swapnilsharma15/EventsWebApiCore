using EventsWebApiCore.Data;
using EventsWebApiCore.HelperMethods;
using EventsWebApiCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsWebApiCore.Services
{
    public class EventService : IEventService
    {
        private readonly EventDBContext _dbContext;

        public EventService(EventDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Event> CreateEvent(Event eventItem)
        {
            var result = _dbContext.Events.Add(eventItem);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<EventUserViewModel> GetEventInfo(int id)
        {
            var eventItem = _dbContext.Events.Where(x => x.Id == id).FirstOrDefault();
            if (eventItem == null)
            {
                return null;
            }
            GetUserListFromApi getUserListFromApi = new GetUserListFromApi();
            EventUserViewModel eventUserViewModel = new EventUserViewModel();
            eventUserViewModel.Event = eventItem;
            eventUserViewModel.User = await getUserListFromApi.GetUserListFromApiMethod();

            return eventUserViewModel;
        }

        public async Task<IEnumerable<Event>> GetEvents(int page,int pageSize)
        {
            var query = _dbContext.Events.AsQueryable();

            int skip = (page - 1) * pageSize;

            var events = await query
                .OrderBy(e => e.Id)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            return events;
        }

        public async Task<Event> UpdateEventDetails(Event updatedEvent)
        {
            if (updatedEvent == null)
            {
                return null;
            }

            var existingEvent = await _dbContext.Events.FindAsync(updatedEvent.Id);
            if (existingEvent == null)
            {
                return null;
            }

            // Update properties of existingEvent with updatedEvent data
            existingEvent.Title = updatedEvent.Title;
            existingEvent.EventDateTimeOffset = updatedEvent.EventDateTimeOffset;
            existingEvent.Description = updatedEvent.Description;

            _dbContext.Update(existingEvent);
            await _dbContext.SaveChangesAsync();

            return existingEvent;
        }

        public bool DeleteEvent(int Id)
        {
            var filteredData = _dbContext.Events.Where(x => x.Id == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
    }
}
