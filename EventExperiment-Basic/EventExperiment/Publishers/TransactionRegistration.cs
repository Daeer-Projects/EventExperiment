namespace EventExperiment.Publishers
{
    using System;
    using System.Threading.Tasks;

    using EventArguments;

    public class TransactionRegistration
    {
        public event EventHandler<TransactionRegistrationEventArgs> TransactionHandler;
        public event EventHandler<LogReceivedEventArgs> LogHandler;

        public void TransactionReceivedEvent(int foundSite, Guid transactionId)
        {
            this.LogHandler?.Invoke(this, new LogReceivedEventArgs(
                new Exception("TransactionRegistration: Error."),
                false,
                "TransactionRegistration - Logging message",
                $"TransactionRegistration: Transaction Received...  Processing!",
                transactionId));

            this.TransactionHandler?.Invoke(this,
                new TransactionRegistrationEventArgs(
                    new Exception("Transaction Handler: Error."), 
                    false,
                    "Transaction Received Event.", 
                    "Hello.  Transaction Received.", 
                    foundSite,
                    transactionId));
        }
        
        public async Task OnSiteCheckEvent(object sender, SiteFoundEventArgs eventArgs)
        {
            this.LogHandler?.Invoke(this, new LogReceivedEventArgs(
                new Exception("TransactionRegistration: Error."),
                false,
                "TransactionRegistration - Logging message",
                $"TransactionRegistration: Transaction: Site Check Processed.",
                eventArgs.TransactionId));

            this.LogHandler?.Invoke(this, new LogReceivedEventArgs(
                new Exception("TransactionRegistration: Error."),
                false,
                "TransactionRegistration - Logging message",
                $"TransactionRegistration: Transaction: Site found.",
                eventArgs.TransactionId));

            this.LogHandler?.Invoke(this, new LogReceivedEventArgs(
                new Exception("TransactionRegistration: Error."),
                false,
                "TransactionRegistration - Logging message",
                $"TransactionRegistration: Site Details: {eventArgs.SiteName}.",
                eventArgs.TransactionId));

        }

        public async Task OnCustomerCheckEvent(object sender, CustomerFoundEventArgs eventArgs)
        {
            this.LogHandler?.Invoke(this, new LogReceivedEventArgs(
                new Exception("TransactionRegistration: Error."),
                false,
                "TransactionRegistration - Logging message",
                $"TransactionRegistration: Customer Check Processed.",
                eventArgs.TransactionId));

            this.LogHandler?.Invoke(this, new LogReceivedEventArgs(
                new Exception("TransactionRegistration: Error."),
                false,
                "TransactionRegistration - Logging message",
                $"TransactionRegistration: Customer found.",
                eventArgs.TransactionId));

            this.LogHandler?.Invoke(this, new LogReceivedEventArgs(
                new Exception("TransactionRegistration: Error."),
                false,
                "TransactionRegistration - Logging message",
                $"TransactionRegistration: Customer Details: {eventArgs.CustomerNumber}.",
                eventArgs.TransactionId));

        }
    }
}