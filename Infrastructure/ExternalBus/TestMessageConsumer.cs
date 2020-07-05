using System.Threading.Tasks;
using MassTransit;

namespace RecruitR.Infrastructure.ExternalBus
{
    public class TestMessageConsumer : IConsumer<TestMessage>
    {
        public TestMessageConsumer()
        {
            
        }

        public Task Consume(ConsumeContext<TestMessage> context)
        {
            return Task.CompletedTask;
        }
    }
}