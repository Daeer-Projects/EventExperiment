namespace EventExperimentServices.Services
{
    public class EventPubSubContainer
    {
        public MessageService MessageService { get; }
        public MessageTypeSwitchService MessageTypeSwitchService { get; }

        public EventPubSubContainer(MessageService messageService, MessageTypeSwitchService typeSwitchService)
        {
            MessageService = messageService;
            MessageTypeSwitchService = typeSwitchService;
        }
    }
}