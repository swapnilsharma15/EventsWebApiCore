using EventsWebApiCore.Controllers;
using EventsWebApiCore.Models;
using EventsWebApiCore.Services;
using Moq;

namespace EventsWebApiCore.Tests
{
    public class EventsControllerTests
    {
        private readonly Mock<IEventService> eventService;
        public EventsControllerTests()
        {
            eventService = new Mock<IEventService>();
        }

        [Fact]
        public void GetEvents()
        {
            var eventsController = new EventsController(eventService.Object);

            //act
            var eventResult = eventsController.GetEvents(1,1);

            //assert
            Assert.NotNull(eventResult);
        }

        [Fact]
        public void GetEvent()
        {
            var eventsController = new EventsController(eventService.Object);

            //act
            var eventResult = eventsController.GetEvent(1);

            //assert
            Assert.NotNull(eventResult);
        }

        [Fact]
        public void CreateEvent()
        {
            Event eventObj = new Event();
            eventObj.Id = 1;
            eventObj.Title = "test";
            eventObj.Description = "test descrp";
            eventObj.EventDateTimeOffset = DateTimeOffset.Now;

            var eventsController = new EventsController(eventService.Object);

            //act
            var eventResult = eventsController.CreateEvent(eventObj);

            //assert
            Assert.NotNull(eventResult);
        }

        [Fact]
        public void EditEvent()
        {
            Event eventObj = new Event();
            eventObj.Id = 1;
            eventObj.Title = "test";
            eventObj.Description = "test descrp";
            eventObj.EventDateTimeOffset = DateTimeOffset.Now;

            var eventsController = new EventsController(eventService.Object);

            //act
            var eventResult = eventsController.EditEvent(eventObj);

            //assert
            Assert.NotNull(eventResult);
        }

        [Fact]
        public void DeleteEvent()
        {
            var eventsController = new EventsController(eventService.Object);

            //act
            var eventResult = eventsController.DeleteEvent(1);

            //assert
            Assert.NotNull(eventResult);
        }
    }
}
