using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;
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

        [HttpPost("mass-transit-rabbit-mq")]
        public async Task SendMessage()
        {
            await _bus.Publish(new TestMessage {Content = "Hello rabbit", Id = Guid.NewGuid()});
        }

        [HttpGet("consul")]
        public IEnumerable<string> GetConsulConfig()
        {
            var consulClient = new ConsulClient(c => c.Address = new Uri("http://localhost:8500"));
            var services = consulClient.Agent.Services().Result.Response;

            return services.Keys;

        }

        
    }
}