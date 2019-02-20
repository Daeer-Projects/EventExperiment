using System;
using System.Collections.Generic;
using System.Text;
using Easy.MessageHub;
using EventExperimentServices.Common;
using EventExperimentServices.Types;
using Serilog;

namespace EventExperiment_EasyHub.Services
{
    public class MessageService
    {
        private readonly ILogger _logger;
        private readonly IMessageHub _messageHub;

        public MessageService(ILogger log, IMessageHub hub)
        {
            _logger = log;
            _messageHub = hub;
        }

        public void SendMessage(Message message)
        {
            _logger.Information(Constants.LogMessageTemplate, message.MessageId, GetType().Name,
                "SendMessageEvent", "Sent message event raised.");

            _messageHub.Publish(message);
        }
    }
}
