namespace EventExperiment.Publishers
{
    using System;

    using EventArguments;

    public class CustomerPublisher
    {
        public event EventHandler<CustomerFoundEventArgs> CustomerFoundHandler;
        public event EventHandler<LogReceivedEventArgs> LogHandler;

        public void RegisterCustomerFoundEvent(int customerNumber, Guid transactionId)
        {
            //Console.WriteLine("Customer found event raised.");

            this.LogHandler?.Invoke(this, new LogReceivedEventArgs(
                new Exception("CustomerPublisher: Error."),
                false,
                "CustomerPublisher - Logging message",
                $"CustomerPublisher: Customer Found Invoked.",
                transactionId));

            this.CustomerFoundHandler?.Invoke(this,
                new CustomerFoundEventArgs(
                    new Exception("CustomerPublisher: Error."),
                    false,
                    "CustomerPublisher - Start Customer Search",
                    customerNumber,
                    transactionId));
        }
    }
}