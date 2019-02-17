namespace EventExperiment.EventArguments
{
    using System;
    using System.ComponentModel;

    public class CustomerFoundEventArgs : AsyncCompletedEventArgs
    {
        public CustomerFoundEventArgs(Exception error, bool cancelled, object userState, int customerNumber, Guid transactionId)
            : base(error, cancelled, userState)
        {
            CustomerNumber = $"Hello.  Customer 00{customerNumber} Found.";
            TransactionId = transactionId;
        }

        public string CustomerNumber { get; }
        public Guid TransactionId { get; }
    }
}