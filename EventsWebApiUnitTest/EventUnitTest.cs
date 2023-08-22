using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using EventsWebApiCore.Controllers;
using EventsWebApiCore.Data;
using EventsWebApiCore.Models;
using EventsWebApiCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

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
    }
}