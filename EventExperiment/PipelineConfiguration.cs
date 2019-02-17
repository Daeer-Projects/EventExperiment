
namespace EventExperiment
{
    using Publishers;
    using Subscribers;

    public class PipelineConfiguration
    {
        public CustomerSubscriber customerSubscriber { get; }

        public CustomerPublisher customerPublisher { get; }

        public SiteSubscriber siteSubscriber { get; }

        public SitePublisher sitePublisher { get; }

        public TransactionRegistration transactionRegistration { get; }

        public LogSubscriber LogSubscriber { get; }

        public PipelineConfiguration(CustomerSubscriber customer, CustomerPublisher customerPub, SiteSubscriber site, SitePublisher sitePub, TransactionRegistration transaction, LogSubscriber logSubscriber)
        {
            this.customerSubscriber = customer;
            this.customerPublisher = customerPub;
            this.siteSubscriber = site;
            this.sitePublisher = sitePub;
            this.transactionRegistration = transaction;
            this.siteSubscriber.SitePublisher = this.sitePublisher;
            this.customerSubscriber.CustomerPublisher = this.customerPublisher;
            this.LogSubscriber = logSubscriber;
        }
    }
}
