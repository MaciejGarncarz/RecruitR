using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RecruitR.Infrastructure.ExternalBus;

namespace RecruitR.API.Controllers
{
    [ApiController]
    [Route("api/dev")]
    public class DevelopmentController
    {
        private readonly IBus _bus;

        public DevelopmentController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task SendMessage()
        {
            await _bus.Publish(new TestMessage {Content = "Hello rabbit", Id = Guid.NewGuid()});
        }
    }
}