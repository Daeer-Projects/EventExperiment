using EventExperiment.Publishers;

namespace EventExperiment.Subscribers
{
    using System;
    using System.Threading.Tasks;

    using EventExperiment.EventArguments;

    public class CustomerSubscriber
    {
        public CustomerPublisher CustomerPublisher { get; set; }
        public event EventHandler<LogReceivedEventArgs> LogHandler;

        public async Task OnTransactionReceivedEvent(object sender, TransactionRegistrationEventArgs eventArgs)
        {
            //Console.WriteLine("** Customer received transaction **");
            this.LogHandler?.Invoke(this, new LogReceivedEventArgs(
                new Exception("CustomerSubscriber: Error."),
                false,
                "CustomerSubscriber - Logging message",
                $"CustomerSubscriber: ** Customer received transaction **",
                eventArgs.TransactionId));

            var random = new Random();

            var customerNumber = random.Next(1, 1000);

            await OnCustomerCheckEvent(customerNumber, eventArgs.TransactionId).ConfigureAwait(false);
        }

        public async Task OnCustomerCheckEvent(int customerNumber, Guid transactionId)
        {
            //Console.WriteLine("Customer Check Event raised.");
            this.LogHandler?.Invoke(this, new LogReceivedEventArgs(
                new Exception("CustomerSubscriber: Error."),
                false,
                "CustomerSubscriber - Logging message",
                $"CustomerSubscriber: Customer Check Event raised.",
                transactionId));

            CustomerPublisher.RegisterCustomerFoundEvent(customerNumber, transactionId);
        }
    }
}