using EventExperimentServices.Services;

namespace EventExperimentServices.Extensions
{
    public static class EventPubSubContainerExtensions
    {
        public static EventPubSubContainer SetUpEventConnections(this EventPubSubContainer container)
        {
            //configuration.transactionRegistration.TransactionHandler +=
            //async (s, e) => await configuration.siteSubscriber.OnTransactionReceivedEvent(s, e).ConfigureAwait(true);

            container.MessageService.MessageHandler += (s, e) => container.MessageTypeSwitchService.OnMessageReceivedEvent(s, e);
            return container;
        }
    }
}