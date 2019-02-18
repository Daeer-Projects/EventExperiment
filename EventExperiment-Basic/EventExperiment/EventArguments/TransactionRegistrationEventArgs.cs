namespace EventExperiment.EventArguments
{
    using System;
    using System.ComponentModel;
    public class TransactionRegistrationEventArgs : AsyncCompletedEventArgs
    {
        public TransactionRegistrationEventArgs(Exception error, bool cancelled, object userState, string message, int siteNumber, Guid transactionId) : base(error, cancelled, userState)
        {
            Message = message;
            SiteNumber = siteNumber;
            TransactionId = transactionId;
        }

        public string Message { get; }

        public int SiteNumber { get; }

        public Guid TransactionId { get; }
    }
}
