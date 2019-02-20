using EventExperimentServices.Services;

namespace EventExperimentServices.Extensions
{
    public static class EventPubSubContainerExtensions
    {
        public static EventPubSubContainer SetUpEventConnections(this EventPubSubContainer container)
        {
            container.MessageService.MessageHandler += (s, e) => 
                container.MessageTypeSwitchService.OnMessageReceivedEvent(s, e);
            return container;
        }
    }
}