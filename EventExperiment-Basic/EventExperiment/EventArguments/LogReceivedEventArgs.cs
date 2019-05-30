namespace EventExperiment.EventArguments
{
    using System;
    using System.ComponentModel;

    public class LogReceivedEventArgs : AsyncCompletedEventArgs
    {
        public LogReceivedEventArgs(Exception error, bool cancelled, object userState, string message, Guid transactionId)
            : base(error, cancelled, userState)
        {
            Message = message;
            TransactionId = transactionId;
        }

        public string Message { get; }
        public Guid TransactionId { get;  }
    }
}