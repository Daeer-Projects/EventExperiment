using System;
using EventExperimentServices.Common;
using EventExperimentServices.EventArguments;
using EventExperimentServices.Types;
using Serilog;

namespace EventExperimentServices.Services
{
    public class MessageService
    {
        private readonly ILogger _logger;
        public event EventHandler<MessageSentReceivedArgs> MessageHandler;

        public MessageService(ILogger log)
        {
            _logger = log;
        }

        /// <exception cref="T:System.Exception">A delegate callback throws an exception.</exception>
        public void SendMessageEvent(Message message)
        {
            _logger.Information(Constants.LogMessageTemplate, message.MessageId, GetType().Name,
                "SendMessageEvent", "Sent message event raised.");
            MessageHandler?.Invoke(this,
                new MessageSentReceivedArgs(
                    new Exception("Message Handler: Error."),
                    false,
                    "Message Sent Event.",
                    message));
        }
    }
}