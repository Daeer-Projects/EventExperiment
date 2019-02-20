using System;
using System.Collections.Generic;
using System.Text;
using Easy.MessageHub;
using EventExperimentServices.Common;
using EventExperimentServices.Types;
using Serilog;

namespace EventExperiment_EasyHub.Services
{
    public class MessageTypeSwitchService
    {
        private readonly ILogger _logger;
        private readonly IMessageHub _messageHub;

        private Guid _token;

        public MessageTypeSwitchService(ILogger log, IMessageHub hub)
        {
            _logger = log;
            _messageHub = hub;

            _token = _messageHub.Subscribe<Message>(OnMessageReceivedEvent);
        }


        /// <exception cref="T:System.Exception">A delegate callback throws an exception.</exception>
        private void OnMessageReceivedEvent(Message message)
        {
            _logger.Information(Constants.LogMessageTemplate, message.MessageId, GetType().Name,
                "OnMessageReceivedEvent", "Message received.  Sending on.");

            switch (message.MessageTypes)
            {
                case Enums.MessageTypes.Movement:
                    {
                        _logger.Information(Constants.LogMessageTemplate, message.MessageId, GetType().Name,
                            "OnMessageReceivedEvent", "Movement type detected. Sending on.");
                        //MovementEventHandler?.Invoke(this,
                        //    new MovementTypeEventArgs(
                        //        new Exception("Movement Handler: Error."),
                        //        false,
                        //        "Movement Sent Event.",
                        //        args.SentMessage.MessageList));
                        //MovementEventHandler(this,
                        //    new MovementTypeEventArgs(
                        //        new Exception("Movement Handler: Error."),
                        //        false,
                        //        "Movement Sent Event.",
                        //        args.SentMessage.MessageList));
                        break;
                    }
                case Enums.MessageTypes.Action:
                    {
                        _logger.Information(Constants.LogMessageTemplate, message.MessageId, GetType().Name,
                            "OnMessageReceivedEvent", "Action type detected. Sending on.");
                        //ActionEventHandler(this,
                        //    new ActionTypeEventArgs(
                        //        new Exception("Action Handler: Error."),
                        //        false,
                        //        "Action Sent Event.",
                        //        args.SentMessage.MessageList));
                        break;
                    }
                case Enums.MessageTypes.Object:
                    {
                        _logger.Information(Constants.LogMessageTemplate, message.MessageId, GetType().Name,
                            "OnMessageReceivedEvent", "Object type detected. Sending on.");
                        //ObjectEventHandler(this,
                        //    new ObjectTypeEventArgs(
                        //        new Exception("Object Handler: Error."),
                        //        false,
                        //        "Object Sent Event.",
                        //        args.SentMessage.MessageList));
                        break;
                    }
                case Enums.MessageTypes.Monster:
                    {
                        _logger.Information(Constants.LogMessageTemplate, message.MessageId, GetType().Name,
                            "OnMessageReceivedEvent", "Monster type detected.  Sending on.");
                        //MonsterEventHandler(this,
                        //    new MonsterTypeEventArgs(
                        //        new Exception("Monster Handler: Error."),
                        //        false,
                        //        "Monster Sent Event.",
                        //        args.SentMessage.MessageList));
                        break;
                    }
                default:
                    {
                        _logger.Error(Constants.LogMessageTemplate, message.MessageId, GetType().Name,
                            "OnMessageReceivedEvent", "Unknown type detected.");
                        throw new ArgumentOutOfRangeException("Unknown type detected.");
                    }
            }
        }
    }
}
