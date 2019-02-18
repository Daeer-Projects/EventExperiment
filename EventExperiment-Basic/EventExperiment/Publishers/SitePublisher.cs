namespace EventExperiment.Publishers
{
    using System;

    using EventArguments;

    public class SitePublisher
    {
        public event EventHandler<SiteFoundEventArgs> SiteFoundHandler;
        public event EventHandler<LogReceivedEventArgs> LogHandler; 
        
        public void StartSiteSearch(int siteNumber, Guid transactionId)
        {
            //Console.WriteLine("Site found event raised.");
            this.LogHandler?.Invoke(this, new LogReceivedEventArgs(
                new Exception("SitePublisher: Error."),
                false,
                "SitePublisher - Logging message",
                $"SitePublisher: Site Search Invoked.",
                transactionId));

            this.SiteFoundHandler?.Invoke(this, 
                new SiteFoundEventArgs(
                    new Exception("SitePublisher: Error."), 
                    false, 
                    "SitePublisher - Start Site Search", 
                    siteNumber,
                    transactionId));
        }
    }
}
