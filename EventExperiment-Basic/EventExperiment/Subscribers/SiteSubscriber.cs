namespace EventExperiment.Subscribers
{
    using System;
    using System.Threading.Tasks;

    using EventArguments;
    using Publishers;

    public class SiteSubscriber
    {
        public SitePublisher SitePublisher { get; set; }
        public event EventHandler<LogReceivedEventArgs> LogHandler;

        public async Task OnTransactionReceivedEvent(object sender, TransactionRegistrationEventArgs eventArgs)
        {
            //Console.WriteLine("** Site received transaction **");
            //Console.WriteLine($"Site: Transaction Message: {eventArgs.Message}.");

            this.LogHandler?.Invoke(this, new LogReceivedEventArgs(
                new Exception("SiteSubscriber: Error."),
                false,
                "SiteSubscriber - Logging message",
                $"SiteSubscriber: ** Site received transaction **",
                eventArgs.TransactionId));

            this.LogHandler?.Invoke(this, new LogReceivedEventArgs(
                new Exception("SiteSubscriber: Error."),
                false,
                "SiteSubscriber - Logging message",
                $"SiteSubscriber: Site: Transaction Message: {eventArgs.Message}.",
                eventArgs.TransactionId));

            OnSiteCheckEvent(eventArgs.SiteNumber, eventArgs.TransactionId);
        }

        public void OnSiteCheckEvent(int siteNumber, Guid transactionId)
        {
            //Console.WriteLine("Transaction Check Event raised.");

            this.LogHandler?.Invoke(this, new LogReceivedEventArgs(
                new Exception("SiteSubscriber: Error."),
                false,
                "SiteSubscriber - Logging message",
                $"SiteSubscriber: Transaction Check Event raised.",
                transactionId));

            SitePublisher.StartSiteSearch(siteNumber, transactionId);
        }
    }
}