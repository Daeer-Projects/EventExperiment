namespace EventExperiment.ExtensionMethods
{
    public static class PipelineRegistrationMethods
    {
        public static PipelineConfiguration RegisterSiteSubscriptions(this PipelineConfiguration configuration)
        {
            configuration.transactionRegistration.TransactionHandler += async (s, e) => await configuration.siteSubscriber.OnTransactionReceivedEvent(s, e).ConfigureAwait(true);
            configuration.transactionRegistration.LogHandler += async (s, e) => await configuration.LogSubscriber.OnLogReceivedEvent(s, e).ConfigureAwait(true);
            configuration.siteSubscriber.LogHandler += async (s, e) => await configuration.LogSubscriber.OnLogReceivedEvent(s, e).ConfigureAwait(true);
            return configuration;
        }

        public static PipelineConfiguration RegisterSitePublications(this PipelineConfiguration configuration)
        {
            configuration.sitePublisher.SiteFoundHandler += async (s, e) => await configuration.transactionRegistration.OnSiteCheckEvent(s, e).ConfigureAwait(true);
            configuration.sitePublisher.LogHandler += async (s, e) => await configuration.LogSubscriber.OnLogReceivedEvent(s, e).ConfigureAwait(true);
            return configuration;
        }

        public static PipelineConfiguration RegisterCustomerSubscriptions(this PipelineConfiguration configuration)
        {
            configuration.transactionRegistration.TransactionHandler += async (s, e) => await configuration.customerSubscriber.OnTransactionReceivedEvent(s, e).ConfigureAwait(true);
            configuration.customerSubscriber.LogHandler += async (s, e) => await configuration.LogSubscriber.OnLogReceivedEvent(s, e).ConfigureAwait(true);
            return configuration;
        }

        public static PipelineConfiguration RegisterCustomerPublications(this PipelineConfiguration configuration)
        {
            configuration.customerPublisher.CustomerFoundHandler += async (s, e) => await configuration.transactionRegistration.OnCustomerCheckEvent(s, e).ConfigureAwait(true);
            configuration.customerPublisher.LogHandler += async (s, e) => await configuration.LogSubscriber.OnLogReceivedEvent(s, e).ConfigureAwait(true);
            return configuration;
        }
    }
}