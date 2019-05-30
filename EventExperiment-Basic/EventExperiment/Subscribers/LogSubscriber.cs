namespace EventExperiment.Subscribers
{
    using System.Threading.Tasks;

    using EventArguments;
    using Serilog;

    public class LogSubscriber
    {
        private ILogger Logger { get; }

        public LogSubscriber(ILogger log)
        {
            Logger = log;
        }

        public async Task OnLogReceivedEvent(object sender, LogReceivedEventArgs eventArgs)
        {
            Logger.Information($"TransactionId: {eventArgs.TransactionId} ; Message: {eventArgs.Message}.");
        }
    }
}