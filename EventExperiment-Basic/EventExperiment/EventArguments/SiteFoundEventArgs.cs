namespace EventExperiment.EventArguments
{
    using System;
    using System.ComponentModel;

    public class SiteFoundEventArgs : AsyncCompletedEventArgs
    {
        public SiteFoundEventArgs(Exception error, bool cancelled, object userState, int siteNumber, Guid transactionId) 
            : base(error, cancelled, userState)
        {
            SiteName = $"Hello.  Site 00{siteNumber} Found.";
            TransactionId = transactionId;
        }

        public string SiteName { get; }
        public Guid TransactionId { get; }
    }
}